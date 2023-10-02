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

namespace Sudowin.Win32.WtsApi32
{
    public static partial class Native
    {
        /// <summary>
        /// The WtsEnumerateSessions function retrieves
        /// a list of sessions on a specified terminal server.
        /// </summary>
        /// <param name="serverHandle">
        /// Handle to a terminal server. Specify a handle opened
        /// by the
        /// <see cref="WtsOpenServer">WtsOpenServer</see> 
        /// function, or specify
        /// <see cref="WtsCurrentServerHandle">WtsCurrentServerHandle</see>
        /// to indicate the terminal server on which your application is running.
        /// </param>
        /// <param name="reserved">
        /// Reserved; must be zero.
        /// </param>
        /// <param name="version">
        /// Specifies the version of the enumeration request. Must be 1.
        /// </param>
        /// <param name="wtsSessionInfoStructures">
        /// Pointer to a variable that receives a pointer to an array of
        /// <see cref="WtsSessionInfo">WtsSessionInfo</see> 
        /// structures. Each structure in the array contains
        /// information about a session on the specified terminal server. To free
        /// the returned buffer, call the
        /// <see cref="WtsFreeMemory">WtsFreeMemory</see> function.
        ///
        /// To be able to enumerate a session, you need to have the
        /// Query Information permission. For more information,
        /// see Terminal Services Permissions, http://msdn.microsoft.com/library/en-us/termserv/termserv/terminal_services_permissions.asp.
        /// To modify permissions on a session, use the Terminal Services
        /// Configuration administrative tool.
        /// </param>
        /// <param name="wtsSessionInfoStructuresLength">
        /// Pointer to the variable that receives the number of WtsSessionInfo
        /// structures returned in the ppSessionInfo buffer.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a nonzero value.
        ///
        /// If the function fails, the return value is zero.
        /// To get extended error information, call
        /// <see cref="Marshal.GetLastWin32Error">GetLastWin32Error()</see>
        /// </returns>
        /// <remarks>
        /// This is the native version of
        /// <see cref="Managed.WtsEnumerateSessions">WtsEnumerateSessions</see>.
        /// 
        /// WTSEnumerateSessionsW, https://learn.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtsenumeratesessionsw
        /// </remarks>
        [DllImport(
            "wtsapi32.dll",
            EntryPoint = "WTSEnumerateSessionsW",
            CharSet = CharSet.Unicode,
            SetLastError = true),
            SuppressUnmanagedCodeSecurity
        ]
        public static extern bool WtsEnumerateSessions(
            IntPtr serverHandle,
            uint reserved,
            uint version,
            out IntPtr wtsSessionInfoStructures,
            out uint wtsSessionInfoStructuresLength
        );
    }
}
