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
    /// Used by the StartupInfo structure's Flags member.
    /// </summary>
    [Flags]
    public enum StartupInfoFlags : uint
    {
        /// <summary>
        /// If this value is not specified, the ShowWindow member is ignored.
        /// </summary>
        UseShowWindow = 0x00000001,
        /// <summary>
        /// If this value is not specified, the XSize and YSize members are ignored.
        /// </summary>
        UseSize = 0x00000002,
        /// <summary>
        /// If this value is not specified, the X and Y members are ignored.
        /// </summary>
        UsePosition = 0x00000004,
        /// <summary>
        /// If this value is not specified, the XCountChars and
        /// YCountChars members are ignored.
        /// </summary>
        /// <remarks>
        /// Windows Me/98/95:  This value is not supported.
        /// </remarks>
        UseCountChars = 0x00000008,
        /// <summary>
        /// If this value is not specified, the FillAttribute member is ignored.
        /// </summary>
        UseFillAttribute = 0x00000010,
        /// <summary>
        /// This flag is only valid for console applications running on an x86 computer.
        /// </summary>
        /// <remarks>
        /// Windows Me/98/95:  This value is not supported.
        /// </remarks>
        RunFullScreen = 0x00000020,
        /// <summary>
        /// Indicates that the cursor is in feedback mode for two seconds after
        /// CreateProcess is called. The Working in Background cursor is displayed
        /// (see the Pointers tab in the Mouse control panel utility).
        ///
        /// If during those two seconds the process makes the first GUI call,
        /// the system gives five more seconds to the process. If during those
        /// five seconds the process shows a window, the system gives five more
        /// seconds to the process to finish drawing the window.
        ///
        /// The system turns the feedback cursor off after the first call to GetMessage,
        /// regardless of whether the process is drawing.
        /// </summary>
        ForceOnFeedback = 0x00000040,
        /// <summary>
        /// Indicates that the feedback cursor is forced off while the process
        /// is starting. The Normal Select cursor is displayed.
        /// </summary>
        ForceOffFeedback = 0x00000080,
        /// <summary>
        /// 	Sets the standard input, standard output, and standard error handles
        /// 	for the process to the handles specified in the StdInput, StdOutput,
        /// 	and StdError members of the StartupInfo structure. For this to work
        /// 	properly, the handles must be inheritable and the CreateProcess
        /// 	function's InheritHandles parameter must be set to TRUE. For more
        /// 	information, see Handle Inheritance, http://msdn.microsoft.com/library/en-us/sysinfo/base/handle_inheritance.asp.
        /// 	
        /// If this value is not specified, the StdInput, StdOutput, and StdError
        /// members of the StartupInfo structure are ignored.
        /// </summary>
        UseStdHandles = 0x00000100,
    }

    /// <summary>
    /// The StartupInfo structure is used with the CreateProcess,
    /// CreateProcessAsUser, and CreateProcessWithLogonW functions
    /// to specify the window station, desktop, standard handles,
    /// and appearance of the main window for the new process.
    /// </summary>
    /// <remarks>
    /// For graphical user interface (GUI) processes, this information affects
    /// the first window created by the CreateWindow function and shown by the
    /// ShowWindow function. For console processes, this information affects the
    /// console window if a new console is created for the process. A process can
    /// use the GetStartupInfo function to retrieve the StartupInfo structure
    /// specified when the process was created.
    ///
    /// If a GUI process is being started and neither ForceOnFeedback or
    /// ForceOffFeedback is specified, the process feedback cursor is used.
    /// A GUI process is one whose subsystem is specified as "windows."
    /// 
    /// STARTUPINFOW, https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/ns-processthreadsapi-startupinfow
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct StartupInfo
    {
        /// <summary>
        /// Size of the structure, in bytes.
        /// </summary>
        public uint Size;

        /// <summary>
        /// Reserved. Set this member to NULL before passing the
        /// structure to CreateProcess.
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        public string Reserved;

        /// <summary>
        /// The name of the desktop, or the name of both the desktop and window
        /// station for this process. A backslash in the string indicates that
        /// the string includes both the desktop and window station names.
        /// </summary>
        /// <remarks>
        /// For more information, see https://learn.microsoft.com/en-us/windows/desktop/winstation/thread-connection-to-a-desktop.
        /// </remarks>
        [MarshalAs(UnmanagedType.LPWStr)]
        public string Desktop;

        /// <summary>
        /// For console processes, this is the title displayed in the
        /// title bar if a new console window is created. If NULL, the
        /// name of the executable file is used as the window title
        /// instead. This parameter must be NULL for GUI or console
        /// processes that do not create a new console window.
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        public string Title;

        /// <summary>
        /// If Flags specifies UsePosition, this member is the x offset
        /// of the upper left corner of a window if a new window is created,
        /// in pixels. Otherwise, this member is ignored.
        /// 
        /// The offset is from the upper left corner of the screen. For GUI
        /// processes, the specified position is used the first time the new
        /// process calls CreateWindow to create an overlapped window if the x
        /// parameter of CreateWindow is CwUseDefault.
        /// </summary>
        public uint X;

        /// <summary>
        /// If Flags specifies UsePosition, this member is the y offset
        /// of the upper left corner of a window if a new window is created,
        /// in pixels. Otherwise, this member is ignored.
        /// 
        /// The offset is from the upper left corner of the screen. For GUI
        /// processes, the specified position is used the first time the new
        /// process calls CreateWindow to create an overlapped window if the x
        /// parameter of CreateWindow is CwUseDefault.
        /// </summary>
        public uint Y;

        /// <summary>
        /// If Flags specifies UseSize, this member is the width of the window
        /// if a new window is created, in pixels. Otherwise, this member is ignored.
        ///
        /// For GUI processes, this is used only the first time the new process calls
        /// CreateWindow to create an overlapped window if the nWidth parameter
        /// of CreateWindow is CwUseDefault.
        /// </summary>
        public uint XSize;

        /// <summary>
        /// If Flags specifies UseSize, this member is the height of the window
        /// if a new window is created, in pixels. Otherwise, this member is ignored.
        ///
        /// For GUI processes, this is used only the first time the new process calls
        /// CreateWindow to create an overlapped window if the nWidth parameter
        /// of CreateWindow is CwUseDefault.
        /// </summary>
        public uint YSize;

        /// <summary>
        /// If Flags specifies UseCountChars, if a new console window is created
        /// in a console process, this member specifies the screen buffer width, in
        /// character columns. Otherwise, this member is ignored.
        /// </summary>
        public uint XCountChars;

        /// <summary>
        /// If Flags specifies UseCountChars, if a new console window is created
        /// in a console process, this member specifies the screen buffer height, in
        /// character rows. Otherwise, this member is ignored.
        /// </summary>
        public uint YCountChars;

        /// <summary>
        /// If Flags specifies UseFillAttribute, this member is the initial text
        /// and background colors if a new console window is created in a console
        /// application. Otherwise, this member is ignored.
        ///
        /// This value can be any combination of the following values: 
        /// FOREGROUND_BLUE, FOREGROUND_GREEN, FOREGROUND_RED,
        /// FOREGROUND_INTENSITY, BACKGROUND_BLUE, BACKGROUND_GREEN,
        /// BACKGROUND_RED, and BACKGROUND_INTENSITY.
        /// For example, the following combination of values produces red text
        /// on a white background:
        /// 
        /// <code>
        /// FOREGROUND_RED | BACKGROUND_RED | BACKGROUND_GREEN | BACKGROUND_BLUE
        /// </code>
        /// </summary>
        public uint FillAttribute;

        /// <summary>
        /// Bit field that determines whether certain StartupInfo members are used
        /// when the process creates a window.
        /// </summary>
        /// <seealso cref="StartupInfoFlags"/>
        public StartupInfoFlags Flags;

        /// <summary>
        /// If dwFlags specifies STARTF_USESHOWWINDOW, this member can be any of the
        /// SW_ constants defined in Winuser.h. Otherwise, this member is ignored.
        ///
        /// For GUI processes, wShowWindow specifies the default value the first time
        /// ShowWindow is called. The nCmdShow parameter of ShowWindow is ignored.
        /// In subsequent calls to ShowWindow, the wShowWindow member is used if the
        /// nCmdShow parameter of ShowWindow is set to SW_SHOWDEFAULT.
        /// </summary>
        public ushort ShowWindow;

        /// <summary>
        /// Reserved for use by the C Run-time; must be zero.
        /// </summary>
        public ushort CBReserved2;

        /// <summary>
        /// Reserved for use by the C Run-time; must be NULL.
        /// </summary>
        public IntPtr LPReserved2;

        /// <summary>
        /// If dwFlags specifies STARTF_USESTDHANDLES, this member is a handle to
        /// be used as the standard input handle for the process. Otherwise,
        /// this member is ignored.
        /// </summary>
        public IntPtr StdInput;

        /// <summary>
        /// If dwFlags specifies STARTF_USESTDHANDLES, this member is a handle to
        /// be used as the standard output handle for the process. Otherwise,
        /// this member is ignored.
        /// </summary>
        public IntPtr StdOutput;

        /// <summary>
        /// If dwFlags specifies STARTF_USESTDHANDLES, this member is a handle to
        /// be used as the standard error handle for the process. Otherwise,
        /// this member is ignored.
        /// </summary>
        public IntPtr StdError;

        /// <summary>
        /// Initializes a new instance of the <see cref="StartupInfo"/> struct.
        /// </summary>
        /// <returns>An initialized instance of the struct.</returns>
        public static StartupInfo Create()
        {
            return new StartupInfo
            {
                Size = (uint)Marshal.SizeOf(typeof(StartupInfo))
            };
        }
    }
}
