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

namespace Sudowin.Win32.Kernel32
{
    /// <summary>
    /// The SecurityAttributes structure contains the security descriptor for an
    /// object and specifies whether the handle retrieved by specifying this structure
    /// is inheritable. This structure provides security settings for objects created by
    /// various functions, such as CreateFile, CreatePipe, CreateProcess, RegCreateKeyEx,
    /// or RegSaveKeyEx.
    /// </summary>
    /// <remarks>
    /// SECURITY_ATTRIBUTES, https://learn.microsoft.com/en-us/windows/win32/api/wtypesbase/ns-wtypesbase-security_attributes
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct SecurityAttributes
    {
        /// <summary>
        /// The size, in bytes, of this structure. Set this value to the size of
        /// the SecurityAttributes structure.
        /// </summary>
        public uint Length;

        /// <summary>
        /// A pointer to a security descriptor for the object that controls the sharing of it.
        /// If NULL is specified for this member, the object is assigned the default security
        /// descriptor of the calling process. This is not the same as granting access to everyone
        /// by assigning a NULL discretionary access control list (DACL). The default security
        /// descriptor is based on the default DACL of the access token belonging to the calling
        /// process. By default, the default DACL in the access token of a process allows access
        /// only to the user represented by the access token. If other users must access the object,
        /// you can either create a security descriptor with the appropriate access, or add ACEs
        /// to the DACL that grants access to a group of users.
        /// </summary>
        /// <remarks>
        /// Windows Me/98/95:  The SecurityDescriptor member of this structure is ignored.
        ///	</remarks>
        public IntPtr SecurityDescriptor;

        /// <summary>
        /// A Boolean value that specifies whether the returned handle is inherited when a
        /// new process is created. If this member is TRUE, the new process inherits the handle.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        public bool InheritHandle;

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityAttributes"/> struct.
        /// </summary>
        /// <returns>An initialized instance of the struct.</returns>
        public static SecurityAttributes Create()
        {
            return new SecurityAttributes
            {
                Length = (uint)Marshal.SizeOf(typeof(SecurityAttributes))
            };
        }
    }
}
