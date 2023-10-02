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
        /// The WtsQuerySessionInformation function retrieves session
        /// information for the specified session on the specified terminal server.
        /// It can be used to query session information on local and
        /// remote terminal servers.
        /// </summary>
        /// <param name="serverHandle">
        /// Handle to a terminal server. Specify a handle opened by the
        /// <see cref="Native.WtsOpenServer">WtsOpenServer</see> 
        /// function, or specify WtsCurrentServerHandle to indicate
        /// the terminal server on which your application is running.
        /// </param>
        /// <param name="sessionId">
        /// A Terminal Services session identifier. Any program running
        /// in the context of a service will have a session identifier of
        /// zero (0). You can use the
        /// <see cref="Native.WtsEnumerateSessions">WtsEnumerateSessions</see> 
        /// function to retrieve the identifiers of all sessions on a
        /// specified terminal server.
        ///
        /// To be able to query information for another user's session,
        /// you need to have the Query Information permission. For more information,
        /// see Terminal Services Permissions, http://msdn.microsoft.com/library/en-us/termserv/termserv/terminal_services_permissions.asp.
        /// To modify permissions on a session, use the Terminal Services
        /// Configuration administrative tool.
        /// </param>
        /// <param name="wtsInfo">
        /// Specifies the type of information to retrieve. This parameter can
        /// be one of the values from the
        /// <see cref="WtsInfo">WtsInfo</see> 
        /// enumeration type.
        /// </param>
        /// <param name="wtsInfoValue">
        /// Value of the requested information. The format and contents
        /// of the data depend on the information class specified in the
        /// WtsInfo parameter. To free the returned buffer,
        /// call the WtsFreeMemory function.
        /// </param>
        /// <param name="wtsInfoValueSize">
        /// The size, in bytes, of the data in result.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a nonzero value.
        ///
        /// If the function fails, the return value is zero.
        /// To get extended error information, call
        /// <see cref="Marshal.GetLastWin32Error">GetLastWin32Error()</see>
        /// </returns>
        /// <remarks>
        /// Use <see cref="Managed.WtsQuerySessionInformation">Managed.WtsQuerySessionInformation</see> instead.
        /// 
        /// To retrieve the session id for the current session when Terminal
        /// Services is running, call WtsQuerySessionInformation and specify
        /// WtsCurrentSessionId for the SessionId parameter and WtsSessionId for
        /// the WtsQueryInfoTypes parameter. The session id will be returned in
        /// the wtsQueryInfoValue parameter. If Terminal Services is not running,
        /// calls to WtsQuerySessionInformation fail. In this situation, you can
        /// retrieve the current session id by calling the ProcessIdToSessionId function.
        /// 
        /// To determine whether your application is running on the physical console,
        /// you can do the following:
        ///
        /// As described previously, call WtsQuerySessionInformation and specify
        /// WtsCurrentSessionId for the SessionId parameter and WtsSessionId for
        /// the WtsQueryInfoTypes parameter. The session id returned in wtsQueryInfoValue
        /// is zero for the Terminal Services console session.
        ///
        /// Session 0 might not be attached to the physical console. This is
        /// because session 0 can be attached to a remote session. Additionally,
        /// fast user switching is implemented using Terminal Services sessions.
        /// The first user to log on uses session 0, the next user to log on uses
        /// session 1, and so on. To determine if your application is running
        /// on the physical console, call the WtsGetActiveConsoleSessionId function as follows:
        /// 
        /// <code>
        /// (CurrentSessionId == WtsGetActiveConsoleSessionId ())
        /// </code>
        /// 
        /// It is not necessary that Terminal Services be running for
        /// WtsGetActiveConsoleSessionId to succeed.
        /// 
        /// WTSQuerySessionInformationW, https://learn.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtsquerysessioninformationw
        /// </remarks>
        [DllImport(
            "wtsapi32.dll",
            EntryPoint = "WTSQuerySessionInformationW",
            CharSet = CharSet.Unicode,
            SetLastError = true),
            SuppressUnmanagedCodeSecurity
        ]
        public static extern bool WtsQuerySessionInformation(
            IntPtr serverHandle,
            uint sessionId,
            WtsInfo wtsInfo,
            out IntPtr wtsInfoValue,
            out uint wtsInfoValueSize
        );
    }
}
