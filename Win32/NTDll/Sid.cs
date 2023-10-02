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

namespace Sudowin.Win32.NTDll
{
    public static class WellKnownStringSids
    {
        public const string TrustedInstaller = "S-1-5-80-956008885-3418522649-1831038044-1853292631-2271478464";
    }

    /// <summary>
    /// The
    /// <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-sid">
    /// security identifer
    /// </see> (SID) structure is a variable-length structure used to uniquely
    /// identify users or groups.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SID
    {
        public byte Revision;
        public byte SubAuthorityCount;
        public SIDIdentifierAuthority IdentifierAuthority;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public uint[] SubAuthority;
    }

    /// <summary>
    /// The SIDAndAttributes structure represents a security identifier (SID)
    /// and its attributes. SIDs are used to uniquely identify users or groups.
    /// </summary>
    /// <remarks>
    /// SID_AND_ATTRIBUTES, https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-sid_and_attributes
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct SIDAndAttributes
    {
        public IntPtr Sid;
        public uint Attributes;
    }

    /// <summary>
    /// The
    /// <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-sid_identifier_authority">
    /// SIDIdentifierAuthority
    /// </see> (SID) structure represents the top-level authority of a security
    /// identifier (SID).
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SIDIdentifierAuthority
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public byte[] Value;

        public SIDIdentifierAuthority(byte[] value)
        {
            Value = value;
        }
    }

    /// <summary>
    /// The SIDNameUse enumeration contains values that specify the type of a
    /// security identifier (SID).
    /// </summary>
    /// <remarks>
    /// SID_NAME_USE, https://learn.microsoft.com/en-us/windows/win32/api/winnt/ne-winnt-sid_name_use
    /// </remarks>
    public enum SIDNameUse
    {
        /// <summary>
        /// A user SID.
        /// </summary>
        User = 1,

        /// <summary>
        /// A group SID.
        /// </summary>
        Group,

        /// <summary>
        /// A domain SID.
        /// </summary>
        Domain,

        /// <summary>
        /// An alias SID.
        /// </summary>
        Alias,

        /// <summary>
        /// A SID for a well-known group.
        /// </summary>
        WellKnownGroup,

        /// <summary>
        /// A SID for a deleted account.
        /// </summary>
        DeletedAccount,

        /// <summary>
        /// A SID that is not valid.
        /// </summary>
        Invalid,

        /// <summary>
        /// A SID of unknown type.
        /// </summary>
        Unknown,

        /// <summary>
        /// A SID for a computer.
        /// </summary>
        Computer,

        /// <summary>
        /// A mandatory integrity label SID.
        /// </summary>
        Label,

        /// <summary>
        /// 
        /// </summary>
        LogonSession
    }
}
