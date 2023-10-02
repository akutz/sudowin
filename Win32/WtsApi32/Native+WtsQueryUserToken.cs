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
        ///	<summary>
        /// The WtsQueryUserToken function obtains the primary access token
        /// of the logged-on user specified by the session id. To call this
        /// function successfully, the calling application must be running
        /// within the context of the LocalSystem account, http://msdn.microsoft.com/library/en-us/dllproc/base/localsystem_account.asp,
        /// and have the SE_TCB_NAME privilege. It is not necessary that
        /// Terminal Services be running for the function to succeed,
        /// but if Terminal Services is not running, the only valid session
        /// identifier is zero (0).
        ///
        /// Caution       WtsQueryUserToken is intended for highly trusted
        /// services. Service providers must use caution that they do not
        /// leak user tokens when calling this function. Service providers
        /// must close token handles after they have finished with them.
        /// </summary>
        /// <param name="sessionId">
        /// A Terminal Services session identifier. Any program running
        /// in the context of a service will have a session identifier of
        /// zero (0). You can use the
        /// <see cref="WtsEnumerateSessions">WtsEnumerateSessions</see> 
        /// function to retrieve the identifiers of all sessions on a
        /// specified terminal server.
        ///
        /// To be able to query information for another user's session,
        /// you need to have the Query Information permission. For more information,
        /// see Terminal Services Permissions, http://msdn.microsoft.com/library/en-us/termserv/termserv/terminal_services_permissions.asp.
        /// To modify permissions on a session, use the Terminal Services
        /// Configuration administrative tool.
        /// </param>
        /// <param name="userToken">
        /// If the function succeeds, receives a pointer to the token handle
        /// for the logged-on user. Note that you must call the
        /// <see cref="Native.CloseHandle">CloseHandle</see> 
        /// function to close this handle.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a nonzero value,
        /// and the userToke parameter points to the primary token of the user.
        ///
        /// If the function fails, the return value is zero. To get extended error
        /// information, call <see cref="Marshal.GetLastWin32Error">GetLastWin32Error</see>.
        /// Among other errors, GetLastWin32Error can return one of the following errors.
        /// 
        /// Return code                         Description
        /// ERROR_PRIVILEGE_NOT_HELD            The caller does not have the SE_TCB_NAME privilege.
        /// ERROR_INVALID_PARAMETER             One of the parameters to the function was incorrect; for example, the phToken parameter was passed a NULL parameter.
        /// ERROR_ACCESS_DENIED                 The caller does not have the appropriate permissions to call this function. The caller must be running within the context of the LocalSystem account and have the SE_TCB_NAME privilege.
        /// ERROR_CTX_WINSTATION_NOT_FOUND      The token query is for a session that does not exist.
        /// ERROR_NO_TOKEN                      The token query is for a session in which no user is logged-on. This occurs, for example, when the session is in the idle state.
        /// </returns>
        /// <remarks>
        /// For information about primary tokens, see Access Tokens, http://msdn.microsoft.com/library/en-us/secauthz/security/access_tokens.asp.
        /// For more information about account privileges, see Privileges (http://msdn.microsoft.com/library/en-us/secauthz/security/privileges.asp) 
        /// and Authorization Constants (http://msdn.microsoft.com/library/en-us/secauthz/security/authorization_constants.asp.
        ///
        /// See LocalSystem account (http://msdn.microsoft.com/library/en-us/dllproc/base/localsystem_account.asp) 
        /// for information about the privileges associated with that account.
        /// 
        /// WTSQueryUserToken, https://learn.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtsqueryusertoken
        /// </remarks>
        [DllImport(
            "wtsapi32.dll",
            EntryPoint = "WTSQueryUserToken",
            CharSet = CharSet.Unicode,
            SetLastError = true),
            SuppressUnmanagedCodeSecurity
        ]
        public static extern bool WtsQueryUserToken(
            uint sessionId,
            out IntPtr userToken
        );
    }
}
