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

namespace Sudowin.Win32.WtsApi32
{
    /// <summary>
    /// The WtsConnectState enumeration type contains
    /// values that indicate the connection state of a Terminal
    /// Services session.
    /// </summary>
    /// <remarks>
    /// WTS_CONNECTSTATE_CLASS, https://learn.microsoft.com/en-us/windows/win32/api/wtsapi32/ne-wtsapi32-wts_connectstate_class
    /// </remarks>
    public enum WtsConnectState : int
    {
        /// <summary>
        /// A user logged on to the WinStation
        /// </summary>
        WtsActive,
        /// <summary>
        /// The WinStation is connected to the client.
        /// </summary>
        WtsConnected,
        /// <summary>
        /// The WinStation is in the process of connecting to the client.
        /// </summary>
        WtsConnectQuery,
        /// <summary>
        /// The WinStation is shadowing another WinStation.
        /// </summary>
        WtsShadow,
        /// <summary>
        /// The WinStation is active but the client is disconnected.
        /// </summary>
        WtsDisconnected,
        /// <summary>
        /// The WinStation is waiting for a client to connect.
        /// </summary>
        WtsIdle,
        /// <summary>
        /// The WinStation is listening for a connection.
        /// A listener session waits for requests for new client
        /// connections. No user is logged on a listener session.
        /// A listener session cannot be reset, shadowed, or changed
        /// to a regular client session.
        /// </summary>
        WtsListen,
        /// <summary>
        /// The WinStation is being reset.
        /// </summary>
        WtsReset,
        /// <summary>
        /// The WinStation is down due to an error.
        /// </summary>
        WtsDown,
        /// <summary>
        /// The WinStation is initializing.
        /// </summary>
        WtsInit,
    };
}
