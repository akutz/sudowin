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
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;

namespace Sudowin.Win32.NTDll
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// https://learn.microsoft.com/en-us/windows/win32/secauthz/access-rights-for-access-token-objects
    /// </remarks>
    [Flags]
    public enum TokenAccessFlags : uint
    {
        /// <summary>
        /// Required to change the default owner, primary group, or DACL of an
        /// access token.
        /// </summary>
        AdjustDefault = 0x0080,

        /// <summary>
        /// Required to adjust the attributes of the groups in an access token.
        /// </summary>
        AdjustGroups = 0x0040,

        /// <summary>
        /// Required to enable or disable the privileges in an access token.
        /// </summary>
        AdjustPrivileges = 0x0020,

        /// <summary>
        /// Required to adjust the session ID of an access token. The
        /// SE_TCB_NAME privilege is required.
        /// </summary>
        AdjustSessionID = 0x0100,

        /// <summary>
        /// Required to attach a primary token to a process. The
        /// SE_ASSIGNPRIMARYTOKEN_NAME privilege is also required to accomplish
        /// this task.
        /// </summary>
        AssignPrimary = 0x0001,

        /// <summary>
        /// Required to duplicate an access token.
        /// </summary>
        Duplicate = 0x0002,

        /// <summary>
        /// Same as STANDARD_RIGHTS_EXECUTE.
        /// </summary>
        Execute = 0x00020000,

        /// <summary>
        /// Required to attach an impersonation access token to a process.
        /// </summary>
        Impersonate = 0x0004,

        /// <summary>
        /// Required to query an access token.
        /// </summary>
        Query = 0x0008,

        /// <summary>
        /// Required to query the source of an access token.
        /// </summary>
        QuerySource = 0x0010,

        /// <summary>
        /// Combines STANDARD_RIGHTS_READ and Query.
        /// </summary>
        Read = 0x00020008,

        /// <summary>
        /// Combines STANDARD_RIGHTS_WRITE, AdjustPrivileges, AdjustGroups,
        /// and AdjustDefault.
        /// </summary>
        Write = 0x000200E0,

        /// <summary>
        /// Combines all possible access rights for a token.
        /// </summary>
        AllAccess = 0x000F01FF,

        /// <summary>
        /// 
        /// </summary>
        MaximumAllowed = 0x02000000
    }

    /// <summary>
    /// The TokenDefaultDacl structure specifies a discretionary access
    /// control list (DACL).
    /// </summary>
    /// <remarks>
    /// TOKEN_DEFAULT_DACL, https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-token_default_dacl
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct TokenDefaultDacl
    {
        public IntPtr DefaultDacl;
    }

    /// <summary>
    /// The TokenGroups structure contains information about the group security
    /// identifiers (SIDs) in an access token.
    /// </summary>
    /// <remarks>
    /// TOKEN_GROUPS, https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-token_groups
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct TokenGroups
    {
        public int GroupCount;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public SIDAndAttributes[] Groups;

        public TokenGroups(int privilegeCount)
        {
            GroupCount = privilegeCount;
            Groups = new SIDAndAttributes[32];
        }
    };

    /// <summary>
    /// The TokenOwner structure contains the default owner security identifier
    /// (SID) that will be applied to newly created objects.
    /// </summary>
    /// <remarks>
    /// TOKEN_OWNER, https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-token_owner
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct TokenOwner
    {
        public IntPtr Owner;

        public TokenOwner(IntPtr owner)
        {
            Owner = owner;
        }
    }

    /// <summary>
    /// The TokenPrimaryGroup structure specifies a group security identifier
    /// (SID) for an access token.
    /// </summary>
    /// <remarks>
    /// TOKEN_PRIMARY_GROUP, https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-token_primary_group
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct TokenPrimaryGroup
    {
        public IntPtr PrimaryGroup;
    }

    /// <summary>
    /// The
    /// <see href ="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-token_privileges">
    /// TokenPrivileges
    /// </see>
    /// structure contains information about a set of privileges for an access
    /// token.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TokenPrivileges
    {
        public int PrivilegeCount;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 36)]
        public LUIDAndAttributes[] Privileges;

        public TokenPrivileges(int privilegeCount)
        {
            PrivilegeCount = privilegeCount;
            Privileges = new LUIDAndAttributes[36];
        }
    }

    /// <summary>
    /// The TOKEN_SOURCE structure identifies the source of an access token.
    /// </summary>
    /// <remarks>
    /// TOKEN_SOURCE, https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-token_source
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct TokenSource
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] SourceName;
        public LUID SourceIdentifier;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <exception cref="Win32Exception"></exception>
        public TokenSource(string name)
        {
            SourceName = new byte[8];
            Encoding.GetEncoding(1252).GetBytes(
                name,
                0,
                name.Length,
                SourceName,
                0);

            if (!Advapi32.Native.AllocateLocallyUniqueId(out SourceIdentifier))
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }
    }

    /// <summary>
    /// The TokenType enumeration contains values that differentiate between a
    /// primary token and an impersonation token.
    /// </summary>
    /// <remarks>
    /// TOKEN_TYPE, https://learn.microsoft.com/en-us/windows/win32/api/winnt/ne-winnt-token_type
    /// </remarks>
    public enum TokenType
    {
        /// <summary>
        /// Indicates a primary token.
        /// </summary>
        Primary = 1,

        /// <summary>
        /// Indicates an impersonation token.
        /// </summary>
        Impersonation
    }

    /// <summary>
    /// The TokenUser structure identifies the user associated with an access token.
    /// </summary>
    /// <remarks>
    /// TOKEN_USER, https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-token_user
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct TokenUser
    {
        /// <summary>
        /// Specifies a SIDAndAttributes structure representing the user
        /// associated with the access token. There are currently no attributes
        /// defined for user security identifiers (SIDs).
        /// </summary>
        public SIDAndAttributes User;
    }

    /// <summary>
    /// The
    /// <see cref="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ne-winnt-token_information_class">
    /// TokenInformationClass
    /// </see>
    /// enumeration contains values that specify the type of information being
    /// assigned to or retrieved from an access token.
    /// </summary>
    public enum TokenInformationClass : uint
    {
        User = 1,
        Groups,
        Privileges,
        Owner,
        PrimaryGroup,
        DefaultDacl,
        Source,
        Type,
        ImpersonationLevel,
        Statistics,
        RestrictedSids,
        SessionId,
        GroupsAndPrivileges,
        SessionReference,
        SandBoxInert,
        AuditPolicy,
        Origin,
        ElevationType,
        LinkedToken,
        Elevation,
        HasRestrictions,
        AccessInformation,
        VirtualizationAllowed,
        VirtualizationEnabled,
        IntegrityLevel,
        UIAccess,
        MandatoryPolicy,
        LogonSid,
        IsAppContainer,
        Capabilities,
        AppContainerSid,
        AppContainerNumber,
        UserClaimAttributes,
        DeviceClaimAttributes,
        RestrictedUserClaimAttributes,
        RestrictedDeviceClaimAttributes,
        DeviceGroups,
        RestrictedDeviceGroups,
        SecurityAttributes,
        IsRestricted,
        ProcessTrustLevel,
        PrivateNameSpace,
        SingletonAttributes,
        BnoIsolation,
        ChildProcessFlags,
        IsLessPrivilegedAppContainer,
        IsSandboxed,
        IsAppSilo,
        MaxTokenInfoClass
    }
}
