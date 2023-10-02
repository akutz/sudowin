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
using System.ComponentModel;
using System.Runtime.InteropServices;
using Sudowin.Win32.NTDll;

namespace Sudowin.Win32.Advapi32
{
    public static partial class Managed
    {
        public static SafeGlobalIntPtr GetTokenInformation(
            IntPtr tokenHandle,
            TokenInformationClass tokenInformationClass
        )
        {
            IntPtr buffer;
            uint cbBuffer = 4;

            int error;
            bool status;
            do
            {
                // Allocate and zero out the buffer.
                buffer = Marshal.AllocHGlobal((int)cbBuffer);
                Marshal.Copy(new byte[cbBuffer], 0, buffer, (int)cbBuffer);

                status = Native.GetTokenInformation(
                    tokenHandle,
                    tokenInformationClass,
                    buffer,
                    cbBuffer,
                    out cbBuffer);
                error = Marshal.GetLastWin32Error();

                if (!status)
                {
                    Marshal.FreeHGlobal(buffer);
                }
            } while (!status && (
                error == ErrorCodes.BadLength ||
                error == ErrorCodes.InsufficientBuffer
            ));

            if (!status)
            {
                throw new Win32Exception(error);
            }

            return new SafeGlobalIntPtr(buffer);
        }
    }
}
