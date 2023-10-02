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
    /// <summary>
    /// The ObjectAttributes structure specifies attributes that can be applie
    /// to objects or object handles by routines that create objects and/or
    /// return handles to objects.
    /// </summary>
    /// <remarks>
    /// OBJECT_ATTRIBUTES, https://learn.microsoft.com/en-us/windows/win32/api/ntdef/ns-ntdef-_object_attributes
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct ObjectAttributes : IDisposable
    {
        /// <summary>
        /// The number of bytes of data contained in this structure. The
        /// <see cref="Create"/> method sets this member to
        /// <c>sizeof(ObjectAttributes)</c>.
        /// </summary>
        public int Length;

        /// <summary>
        /// Optional handle to the root object directory for the path name
        /// specified by the ObjectName member.
        /// If RootDirectory is NULL, <see cref="ObjectName"/> must point to a
        /// fully qualified object name that includes the full path to the
        /// target object.
        /// If RootDirectory is non-NULL, <see cref="ObjectName"/> specifies
        /// an object name relative to the RootDirectory directory.
        /// The RootDirectory handle can refer to a file system directory or an
        /// object directory in the object manager namespace.
        /// </summary>
        public IntPtr RootDirectory;

        /// <summary>
        /// A <see cref="UnicodeString"/> that contains the name of the object
        /// for which a handle is to be opened.
        /// This must either be a fully qualified object name, or a relative
        /// path name to the directory specified by the
        /// <see cref="RootDirectory"/> member.
        /// </summary>
        public IntPtr objectName;

        /// <summary>
        /// Bitmask of flags that specify object handle attributes.
        /// </summary>
        public ObjectHandleAttributes Attributes;

        /// <summary>
        /// Specifies a <see cref="Kernel32.SecurityDescriptor"/> for the object
        /// when the object is created. If this member is NULL, the object will
        /// receive default security settings.
        /// </summary>
        public IntPtr SecurityDescriptor;

        /// <summary>
        /// Optional quality of service to be applied to the object when it is
        /// created. Used to indicate the security impersonation level and
        /// context tracking mode (dynamic or static). Currently, the
        /// InitializeObjectAttributes macro sets this member to
        /// <see langword="null"/>.
        /// </summary>
        public IntPtr SecurityQualityOfService;

        /// <summary>
        /// Possible flags for the <see cref="Attributes"/> field.
        /// </summary>
        [Flags]
        public enum ObjectHandleAttributes : uint
        {
            /// <summary>
            /// This handle can be inherited by child processes of the current
            /// process.
            /// </summary>
            Inherit = 0x00000002,

            /// <summary>
            /// This flag only applies to objects that are named within the
            /// object manager. By default, such objects are deleted when all
            /// open handles to them are closed. If this flag is specified, the
            /// object is not deleted when all open handles are closed. Drivers
            /// can use the ZwMakeTemporaryObject routine to make a permanent
            /// object non-permanent.
            /// </summary>
            Permanent = 0x00000010,

            /// <summary>
            /// If this flag is set and the <see cref="ObjectAttributes"/>
            /// structure is passed to a routine that creates an object, the
            /// object can be accessed exclusively. That is, once a process
            /// opens such a handle to the object, no other processes can open
            /// handles to this object.
            /// If this flag is set and the <see cref="ObjectAttributes"/>
            /// structure is passed to a routine that creates an object handle,
            /// the caller is requesting exclusive access to the object for the
            /// process context that the handle was created in. This request can
            /// be granted only if the Exclusive flag was set when the
            /// object was created.
            /// </summary>
            Exclusive = 0x00000020,

            /// <summary>
            /// If this flag is specified, a case-insensitive comparison is used
            /// when matching the name pointed to by the ObjectName member
            /// against the names of existing objects. Otherwise, object names
            /// are compared using the default system settings.
            /// </summary>
            CaseInsensitive = 0x00000040,

            /// <summary>
            /// If this flag is specified, by using the object handle, to a
            /// routine that creates objects and if that object already exists,
            /// the routine should open that object. Otherwise, the routine
            /// creating the object returns an NTSTATUS code of
            /// STATUS_OBJECT_NAME_COLLISION.
            /// </summary>
            OpenIf = 0x00000080,

            /// <summary>
            /// If an object handle, with this flag set, is passed to a routine
            /// that opens objects and if the object is a symbolic link object,
            /// the routine should open the symbolic link object itself, rather
            /// than the object that the symbolic link refers to (which is the
            /// default behavior).
            /// </summary>
            OpenLink = 0x00000100,

            /// <summary>
            /// The handle is created in system process context and can only be
            /// accessed from kernel mode.
            /// </summary>
            KernelHandle = 0x00000200,

            /// <summary>
            /// The routine that opens the handle should enforce all access
            /// checks for the object, even if the handle is being opened in
            /// kernel mode.
            /// </summary>
            ForceAccessCheck = 0x00000400,

            /// <summary>
            /// The mask of all valid attributes.
            /// </summary>
            ValidAttributes = 0x000007F2,
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectAttributes"/>
        /// structure.
        /// </summary>
        /// <returns>An <see cref="ObjectAttributes"/> instance with
        /// <see cref="Length"/> initialized.</returns>
        public ObjectAttributes(string name, ObjectHandleAttributes attrs)
        {
            RootDirectory = IntPtr.Zero;
            objectName = IntPtr.Zero;
            Attributes = attrs;
            SecurityDescriptor = IntPtr.Zero;
            SecurityQualityOfService = IntPtr.Zero;

            Length = Marshal.SizeOf(typeof(ObjectAttributes));
            ObjectName = new UnicodeString(name);
        }

        public UnicodeString ObjectName
        {
            get
            {
                return (UnicodeString)Marshal.PtrToStructure(
                    objectName, typeof(UnicodeString));
            }

            set
            {
                bool fDeleteOld = objectName != IntPtr.Zero;
                if (!fDeleteOld)
                {
                    objectName = Marshal.AllocHGlobal(Marshal.SizeOf(value));
                }
                Marshal.StructureToPtr(value, objectName, fDeleteOld);
            }
        }

    public void Dispose()
        {
            if (objectName != IntPtr.Zero)
            {
                Marshal.DestroyStructure(objectName, typeof(UnicodeString));
                Marshal.FreeHGlobal(objectName);
                objectName = IntPtr.Zero;
            }
        }
    }
}
