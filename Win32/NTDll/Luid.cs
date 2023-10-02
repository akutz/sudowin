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
    public static class WellKnownLuids
    {
        public static readonly LUID Anonymous = new LUID(0x3e6, 0);
        public static readonly LUID System = new LUID(0x3e7, 0);
    }

    /// <summary>
    /// A locally unique identifier (LUID).
    /// </summary>
    /// <remarks>
    /// LUID, https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-luid
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct LUID
    {
        public uint LowPart;
        public uint HighPart;

        public LUID(uint lowPart, uint highPart)
        {
            LowPart = lowPart;
            HighPart = highPart;
        }
    }

    /// <summary>
    /// The
    /// <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-luid_and_attributes">
    /// LUIDAndAttributes
    /// </see>
    /// structure represents a locally unique identifier
    /// (LUID) and its attributes.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct LUIDAndAttributes
    {
        public LUID Luid;
        public SePrivilegeAttributes Attributes;
    }
}
