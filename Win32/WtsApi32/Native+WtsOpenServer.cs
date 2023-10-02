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
        /// Handle to the server that this code is running on.
        /// </summary>
        public const int WtsCurrentServerHandle = -1;

        /// <summary>
        /// The WtsOpenServer function opens a handle
        /// to the specified terminal server.
        /// </summary>
        /// <param name="serverName">
        /// A string specifying the NetBIOS name of the terminal server.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a
        /// handle to the specified server.
        ///
        /// If the function fails, the return value is NULL.
        /// To get extended error information, call
        /// <see cref="Marshal.GetLastWin32Error">GetLastWin32Error()</see>
        /// </returns>
        /// <remarks>
        /// When you are finished with the handle returned by WtsOpenServer,
        /// call the WtsCloseServer function to close it.
        ///
        /// You do not need to open a handle for operations performed on the
        /// terminal server on which your application is running. Use the constant
        /// <see cref="WtsCurrentServerHandle">WtsCurrentServerHandle</see> instead.
        /// 
        /// WTSOpenServerW, https://learn.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtsopenserverw
        /// </remarks>
        [DllImport(
            "wtsapi32.dll",
            EntryPoint = "WTSOpenServerW",
            CharSet = CharSet.Unicode,
            SetLastError = true),
            SuppressUnmanagedCodeSecurity
        ]
        public static extern IntPtr WtsOpenServer(
            [MarshalAs(UnmanagedType.LPWStr)] string serverName
        );
    }
}
