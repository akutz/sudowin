/*
Copyright (c) 2005-2023, Schley Andrew Kutz <sakutz@gmail.com>
All rights reserved.
Redistribution and use in source and binary forms, with or without modification,
are permitted provided that the following conditions are met:

    * Redistributions of source code must retain the above copyright notice,
    this list of conditions and the following disclaimer.
    * Redistributions in binary form must reproduce the above copyright notice,
    this list of conditions and the following disclaimer in the documentation
    and/or other materials provided with the distribution.
    * Neither the name of Andrew Kutz nor the names of its contributors may
    be used to endorse or promote products derived from this software without
    specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR
ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON
ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/

using System;
using System.Runtime.InteropServices;

namespace Sudowin.Win32.NTDll
{
    public static partial class Managed
    {
        public static IntPtr CreateTrustedInstallerToken(
            IntPtr srcToken,
            TokenType tokenType,
            SecurityImpersonationLevel impersonationLevel,
            string[] extraStringSids
        )
        {
            var authId = WellKnownLuids.Anonymous;
            var tokenSource = new TokenSource("*SYSTEM*");
            tokenSource.SourceIdentifier.HighPart = 0;
            tokenSource.SourceIdentifier.LowPart = 0;

            var pTrustedInstallerSid = Advapi32.Managed.ConvertStringSidToSid(
                WellKnownStringSids.TrustedInstaller
            );

            var tokenPrivs = CreateTokenPrivileges(
                SePrivileges.AllNames(),
                SePrivilegeAttributes.Enabled | 
                SePrivilegeAttributes.EnabledByDefault
            );
            //var tokenPrivs = new TokenPrivileges();

            var pTokenUser = Advapi32.Managed.GetTokenInformation(
                srcToken, 
                TokenInformationClass.User
            );
            var pTokenGroups = Advapi32.Managed.GetTokenInformation(
                srcToken,
                TokenInformationClass.Groups
            );
            var pTokenOwner = Advapi32.Managed.GetTokenInformation(
                srcToken,
                TokenInformationClass.Owner
            );
            var pTokenPrimaryGroup = Advapi32.Managed.GetTokenInformation(
                srcToken,
                TokenInformationClass.PrimaryGroup
            );
            var pTokenDefaultDacl = Advapi32.Managed.GetTokenInformation(
                srcToken,
                TokenInformationClass.DefaultDacl
            );

            if (pTokenDefaultDacl.Empty())
            {
                return IntPtr.Zero;
            }

            var tokenUser = Marshal.PtrToStructure<TokenUser>(pTokenUser);
            var tokenGroups = Marshal.PtrToStructure<TokenGroups>(pTokenGroups);
            var tokenOwner = Marshal.PtrToStructure<TokenOwner>(pTokenOwner);
            var tokenPrimaryGroup = Marshal.PtrToStructure<TokenPrimaryGroup>(
                pTokenPrimaryGroup
            );
            var tokenDefaultDacl = Marshal.PtrToStructure<TokenDefaultDacl>(
                pTokenDefaultDacl
            );

            /*
            if (tokenGroups.Groups.Length < 32)
            {
                var tgg = new SIDAndAttributes[32];
                tokenGroups.Groups.CopyTo(tgg, 0);
                tokenGroups.Groups = tgg;
            }

            tokenGroups.Groups[tokenGroups.GroupCount].Sid = pTrustedInstallerSid;
            tokenGroups.Groups[tokenGroups.GroupCount].Attributes = (uint) (
                SeGroupAttributes.Owner |
                SeGroupAttributes.EnabledByDefault |
                SeGroupAttributes.Enabled
            );
            tokenGroups.GroupCount++;

            if (extraStringSids != null)
            {
                for (var i = 0; i < extraStringSids.Length; i++)
                {
                    if (tokenGroups.GroupCount >= 32)
                    {
                        continue;
                    }

                    var pSid = Advapi32.Managed.ConvertStringSidToSid(
                        extraStringSids[i]
                    );
                    tokenGroups.Groups[tokenGroups.GroupCount].Sid = pSid;
                    tokenGroups.Groups[tokenGroups.GroupCount].Attributes = (uint)(
                        SeGroupAttributes.Mandatory |
                        SeGroupAttributes.Enabled
                    );
                    tokenGroups.GroupCount++;
                }
            }
            */

            var expirationTime = new LargeInteger(-1L);
            var sqos = new SecurityQualityOfService(
                impersonationLevel,
                SecurityContextTrackingMode.StaticTracking,
                false
            );
            var oa = new ObjectAttributes(string.Empty, 0);
            IntPtr pSqos = Marshal.AllocHGlobal(Marshal.SizeOf(sqos));
            Marshal.StructureToPtr(sqos, pSqos, true);
            oa.SecurityQualityOfService = pSqos;

            var status = Native.ZwCreateToken(
                out IntPtr hToken,
                TokenAccessFlags.AllAccess,
                ref oa,
                tokenType,
                ref authId,
                ref expirationTime,
                ref tokenUser,
                ref tokenGroups,
                ref tokenPrivs,
                ref tokenOwner,
                ref tokenPrimaryGroup,
                ref tokenDefaultDacl,
                ref tokenSource);

            if (status != NTStatus.Success)
            {
                throw new NtStatusException(status);
            }

            return hToken;
        }
    }
}
