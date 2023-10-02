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
    /// The WtsInfo enumeration type contains values that
    /// indicate the type of session information to retrieve in a
    /// call to the <see cref="WtsQuerySessionInformation"/> function.
    /// </summary>
    /// <remarks>
    /// WTS_INFO_CLASS, https://learn.microsoft.com/en-us/windows/win32/api/wtsapi32/ne-wtsapi32-wts_info_class
    /// </remarks>
    public enum WtsInfo
    {
        /// <summary>
        /// A string containing the name of the initial program
        /// that Terminal Services runs when the user logs on.
        /// </summary>
        WtsInitialProgram,
        /// <summary>
        /// A string containing the published name of
        /// the application the session is running.
        /// </summary>
        WtsApplicationName,
        /// <summary>
        /// A string containing the default directory
        /// used when launching the initial program.
        /// </summary>
        WtsWorkingDirectory,
        /// <summary>
        /// Not used.
        /// </summary>
        WtsOemId,
        /// <summary>
        /// An INT value containing the session identifier.
        /// </summary>
        WtsSessionId,
        /// <summary>
        /// A string containing the name of the user
        /// associated with the session.
        /// </summary>
        /// <remarks>
        /// The user name will be returned in this format,
        /// DOMAIN|LOCALMACHINE\USERNAME.
        /// </remarks>
        /// <example>
        /// User 'akutz' logs into the computer 'ALCHEMIST'
        /// with his domain credentials. The WtsUserName
        /// will look like: AUSTIN\akutz.
        /// 
        /// User 'sakutz' logs into the computer 'ALCHEMIST'
        /// with his local credentials. Thee WtsUserName
        /// will look like: ALCHEMIST\sakutz.
        /// </example>
        WtsUserName,
        /// <summary>
        /// A string containing the name of the Terminal Services session.
        /// </summary>
        /// <remarks>
        /// Despite its name, specifying this type does not return the
        /// window station name. Rather, it returns the name of the
        /// Terminal Services session. Each Terminal Services session is
        /// associated with an interactive window station. Currently,
        /// since the only supported window station name for an interactive
        /// window station is "WinSta0", each session is associated with its
        /// own "WinSta0" window station. For more information, see Windows
        /// Stations, http://msdn.microsoft.com/library/en-us/dllproc/base/window_stations.asp.
        /// </remarks>
        WtsWinStationName,
        /// <summary>
        /// A string containing the name of the domain to
        /// which the logged-on user belongs.
        /// </summary>
        WtsDomainName,
        /// <summary>
        /// The session's current connection state.
        /// </summary>
        /// <seealso cref="WtsConnectionState"/>
        WtsConnectState,
        /// <summary>
        /// An INT value containing the build number of the client.
        /// </summary>
        WtsClientBuildNumber,
        /// <summary>
        /// A string containing the name of the client.
        /// </summary>
        WtsClientName,
        /// <summary>
        /// A string containing the directory in which the client is installed.
        /// </summary>
        WtsClientDirectory,
        /// <summary>
        /// An INT client-specific product identifier.
        /// </summary>
        WtsClientProductId,
        /// <summary>
        /// An INT value containing a client-specific hardware identifier.
        /// </summary>
        WtsClientHardwareId,
        /// <summary>
        /// The network type and network address of the client.
        /// </summary>
        WtsClientAddress,
        /// <summary>
        /// Information about the display resolution of the client.
        /// </summary>
        WtsClientDisplay,
        /// <summary>
        /// An INT value specifying information about the
        /// protocol type for the session.
        /// </summary>
        WtsClientProtocolType,
    };
}
