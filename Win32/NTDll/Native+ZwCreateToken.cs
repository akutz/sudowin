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
using System.Security;

namespace Sudowin.Win32.NTDll
{
    public partial class Native
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tokenHandle"></param>
        /// <param name="desiredAccess"></param>
        /// <param name="objectAttributes"></param>
        /// <param name="tokenType"></param>
        /// <param name="authenticationId"></param>
        /// <param name="expirationTime"></param>
        /// <param name="tokenUser"></param>
        /// <param name="tokenGroups"></param>
        /// <param name="tokenPrivileges"></param>
        /// <param name="tokenOwner"></param>
        /// <param name="tokenPrimaryGroup"></param>
        /// <param name="tokenDefaultDacl"></param>
        /// <param name="tokenSource"></param>
        /// <returns></returns>
        /// <remarks>
        /// ZwCreateToken, https://processhacker.sourceforge.io/doc/ntzwapi_8h.html#a0de45199e092a6f12fe87940154c05b4
        /// </remarks>
        [DllImport(
             "ntdll.dll",
             EntryPoint = "ZwCreateToken",
             CharSet = CharSet.Unicode,
             SetLastError = true),
             SuppressUnmanagedCodeSecurity
        ]
        public static extern NTStatus ZwCreateToken(
            out IntPtr tokenHandle,
            TokenAccessFlags desiredAccess,
            ref ObjectAttributes objectAttributes,
            TokenType tokenType,
            ref LUID authenticationId,
            ref LargeInteger expirationTime,
            ref TokenUser tokenUser,
            ref TokenGroups tokenGroups,
            ref TokenPrivileges tokenPrivileges,
            ref TokenOwner tokenOwner,
            ref TokenPrimaryGroup tokenPrimaryGroup,
            ref TokenDefaultDacl tokenDefaultDacl,
            ref TokenSource tokenSource);
    }
}
