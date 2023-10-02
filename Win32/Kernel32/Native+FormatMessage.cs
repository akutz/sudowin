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

namespace Sudowin.Win32.Kernel32
{
    /// <summary>
    /// Please see <see cref="Native.FormatMessage">FormatMessage</see> for more
    /// information.
    /// </summary>
    [Flags]
    public enum FormatMessageFlags : uint
    {
        AllocateBuffer = 0x00000100,
        IgnoreInserts = 0x00000200,
        FromString = 0x00000400,
        FromHModule = 0x00000800,
        FromSystem = 0x00001000,
        ArgumentArray = 0x00002000
    }

    public static partial class Native
    {
        /// <summary>
        /// The
        /// <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-formatmessagew">
        /// FormatMessage
        /// </see>
        /// function Formats a message string. The function requires a message
        /// definition as input. The message definition can come from a buffer
        /// passed into the function. It can come from a message table resource
        /// in an already-loaded module. Or the caller can ask the function to
        /// search the system's message table resource(s) for the message
        /// definition. The function finds the message definition in a message
        /// table resource based on a message identifier and a language
        /// identifier. The function copies the formatted message text to an
        /// output buffer, processing any embedded insert sequences if
        /// requested.
        /// </summary>
        [DllImport(
            "kernel32.dll",
            EntryPoint = "FormatMessageW",
            CharSet = CharSet.Unicode,
            SetLastError = true),
            SuppressUnmanagedCodeSecurity
        ]
        public static extern uint FormatMessage(
            FormatMessageFlags flags,
            IntPtr source,
            uint messageId,
            uint languageId,
            ref IntPtr buffer,
            uint cbBuffer,
            IntPtr args
        );
    }
}
