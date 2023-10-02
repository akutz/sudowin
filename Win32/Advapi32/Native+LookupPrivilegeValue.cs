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
using System.Runtime.InteropServices;
using System.Security;

namespace Sudowin.Win32.Advapi32
{
    public static partial class Native
    {
        /// <summary>
        /// The LookupPrivilegeValue function retrieves the locally unique
        /// identifier (LUID) used on a specified system to locally represent
        /// the specified privilege name.
        /// </summary>
        /// <param name="systemName">
        /// A pointer to a null-terminated string that specifies the name of the
        /// system on which the privilege name is retrieved. If a null string is
        /// specified, the function attempts to find the privilege name on the
        /// local system.
        /// </param>
        /// <param name="name">
        /// A pointer to a null-terminated string that specifies the name of the
        /// privilege, as defined in the Winnt.h header file. For example, this
        /// parameter could specify the constant, SE_SECURITY_NAME, or its
        /// corresponding string, "SeSecurityPrivilege".
        /// </param>
        /// <param name="luid">
        /// A pointer to a variable that receives the LUID by which the
        /// privilege is known on the system specified by the
        /// <paramref name="systemName"/> parameter.
        /// </param>
        /// <returns>
        /// If the function succeeds, the function returns nonzero.
        /// If the function fails, it returns zero. To get extended error
        /// information, call GetLastError.
        /// </returns>
        /// <remarks>
        /// LookupPrivilegeValueW, https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-lookupprivilegevaluew
        /// </remarks>
        [DllImport(
            "advapi32.dll",
            EntryPoint = "LookupPrivilegeValueW",
            CharSet = CharSet.Unicode,
            SetLastError = true),
            SuppressUnmanagedCodeSecurity
        ]
        public static extern bool LookupPrivilegeValue(
            [MarshalAs(UnmanagedType.LPWStr)] string systemName,
            [MarshalAs(UnmanagedType.LPWStr)] string name,
            ref LUID luid
        );
    }
}
