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
    /// Represents a 64-bit signed integer value.
    /// </summary>
    /// <remarks>
    /// LARGE_INTEGER, https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-large_integer-r1
    /// </remarks>
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct LargeInteger
    {
        [FieldOffset(0)]
        public uint Low;

        [FieldOffset(4)]
        public uint High;
        
        [FieldOffset(0)]
        public long QuadPart;

        public LargeInteger(uint low, uint high)
        {
            Low = low;
            High = high;
            QuadPart = 0L;
        }

        public LargeInteger(long quad)
        {
            Low = 0;
            High = 0;
            QuadPart = quad;
        }

        public long ToInt64()
        {
            return ((long)High << 32) | Low;
        }

        public static LargeInteger FromInt64(long value)
        {
            return new LargeInteger
            {
                Low = (uint)(value),
                High = (uint)((value >> 32))
            };
        }
    }
}
