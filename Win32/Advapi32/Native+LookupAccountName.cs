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

using Sudowin.Win32.NTDll;
using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace Sudowin.Win32.Advapi32
{
    public static partial class Native
    {
        /// <summary>
        /// The
        /// <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-lookupaccountnamew">
        /// LookupPrivilegeName
        /// </see>
        /// function accepts the name of a system and an account as input. It
        /// retrieves a security identifier (SID) for the account and the name
        /// of the domain on which the account was found.
        /// </summary>
        /// <param name="systemName">
        /// A pointer to a null-terminated character string that specifies the
        /// name of the system. This string can be the name of a remote
        /// computer. If this string is NULL, the account name translation
        /// begins on the local system. If the name cannot be resolved on the
        /// local system, this function will try to resolve the name using
        /// domain controllers trusted by the local system. Generally, specify
        /// a value for lpSystemName only when the account is in an untrusted
        /// domain and the name of a computer in that domain is known.
        /// </param>
        /// <param name="accountName">
        /// A pointer to a null-terminated string that specifies the account
        /// name.
        /// </param>
        /// <param name="sid" />
        /// <param name="sidLength" />
        /// <param name="referencedDomainName" />
        /// <param name="referencedDomainNameLength" />
        /// <param name="sidNameUse" />
        /// <returns />
        [DllImport(
            "advapi32.dll",
            EntryPoint = "LookupAccountNameW",
            CharSet = CharSet.Unicode,
            SetLastError = true),
            SuppressUnmanagedCodeSecurity
        ]
        public static extern bool LookupAccountName(
            [MarshalAs(UnmanagedType.LPWStr)] string systemName,
            [MarshalAs(UnmanagedType.LPWStr)] string accountName,
            IntPtr sid,
            ref uint sidLength,
            [Out] char[] referencedDomainName,
            ref uint referencedDomainNameLength,
            out SIDNameUse sidNameUse
        );
    }
}
