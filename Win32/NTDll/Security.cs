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

using System.Runtime.InteropServices;

namespace Sudowin.Win32.NTDll
{
    /// <summary>
    /// The
    /// <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ne-winnt-security_impersonation_level">
    /// SecurityImpersonationLevel
    /// </see>
    /// enumeration contains values that specify security impersonation levels.
    /// Security impersonation levels govern the degree to which a server
    /// process can act on behalf of a client process.
    /// </summary>
    public enum SecurityImpersonationLevel : uint
    {
        /// <summary>
        /// The server process cannot obtain identification information about
        /// the client, and it cannot impersonate the client. It is defined with
        /// no value given, and thus, by ANSI C rules, defaults to a value of
        /// zero.
        /// </summary>
        Anonymous,

        /// <summary>
        /// The server process can obtain information about the client, such as
        /// security identifiers and privileges, but it cannot impersonate the
        /// client. This is useful for servers that export their own objects,
        /// for example, database products that export tables and views. Using
        /// the retrieved client-security information, the server can make
        /// access-validation decisions without being able to use other services
        /// that are using the client's security context.
        /// </summary>
        Identification,

        /// <summary>
        /// The server process can impersonate the client's security context on
        /// its local system. The server cannot impersonate the client on remote
        /// systems.
        /// </summary>
        Impersonation,

        /// <summary>
        /// The server process can impersonate the client's security context on
        /// remote systems.
        /// </summary>
        Delegation
    }

    public enum SecurityContextTrackingMode : byte
    {
        StaticTracking = 0,
        DynamicTracking = 1
    }

    /// <summary>
    /// The
    /// <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-security_quality_of_service">
    /// SecurityQualityOfService
    /// </see>
    /// data structure contains information used to support client
    /// impersonation. A client can specify this information when it connects to
    /// a server; the information determines whether the server may impersonate
    /// the client, and if so, to what extent. 
    /// </summary>
    public struct SecurityQualityOfService
    {
        public readonly uint Length;
        public readonly SecurityImpersonationLevel ImpersonationLevel;
        public readonly SecurityContextTrackingMode ContextTrackingMode;
        public readonly bool EffectiveOnly;

        public SecurityQualityOfService(
            SecurityImpersonationLevel impersonationLevel,
            SecurityContextTrackingMode contextTrackingMode,
            bool effectiveOnly
        )
        {
            Length = (uint) Marshal.SizeOf(typeof(SecurityQualityOfService));
            ImpersonationLevel = impersonationLevel;
            ContextTrackingMode = contextTrackingMode;
            EffectiveOnly = effectiveOnly;
        }
    }
}
