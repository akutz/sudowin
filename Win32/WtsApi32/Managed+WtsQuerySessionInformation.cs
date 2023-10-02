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
using System.ComponentModel;

namespace Sudowin.Win32.WtsApi32
{
    public static partial class Managed
    {
        /// <summary>
        /// The WtsQuerySessionInformation method retrieves session
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
        /// be one of the string values from the
        /// <see cref="WtsInfo">WtsInfo</see> enumeration type.
        /// </param>
        /// <param name="wtsInfoValue">
        /// The returned string.
        /// </param>
        /// <returns>The fetched value.</returns>
        /// <remarks>
        /// This method invokes the native
        /// <see cref="Native.WtsQuerySessionInformation">WtsQuerySessionInformation</see>,
        /// copies its results into managed memory, and frees the unmanaged
        /// memory for you.
        /// </remarks>
        /// <exception cref="Win32Exception" />
        public static string WtsQuerySessionInformation(
            IntPtr serverHandle,
            uint sessionId,
            WtsInfo wtsInfo)
        {

            // call the native method to fetch the value
            if (!Native.WtsQuerySessionInformation(
                serverHandle,
                sessionId,
                wtsInfo,
                out IntPtr ppbuff,
                out uint wtsInfoValueSize))
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            // copy the string from unmanaged memory into a managed string and
            // free the unmanaged memory
            string wtsInfoValue = Marshal.PtrToStringUni(ppbuff, (int)wtsInfoValueSize);
            Native.WtsFreeMemory(ppbuff);

            return wtsInfoValue;
        }
    }
}
