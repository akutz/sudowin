using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Sudowin.Win32.Kernel32
{
    /// <summary>
    /// The ProcessInformation structure is used with the CreateProcess,
    /// CreateProcessAsUser, CreateProcessWithLogonW, or CreateProcessWithTokenW
    /// function. This structure contains information about the newly created
    /// process and its primary thread.
    /// </summary>
    /// <remarks>
    /// If the function succeeds, be sure to call the CloseHandle function
    /// to close the Process and Thread handles when you are finished with them.
    /// Otherwise, when the child process exits, the system cannot clean up
    /// these handles because the parent process did not close them. However,
    /// the system will close these handles when the parent process terminates,
    /// so they would be cleaned up at this point.
    /// 
    /// PROCESS_INFORMATION, https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/ns-processthreadsapi-process_information
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct ProcessInformation
    {
        /// <summary>
        /// Handle to the newly created process. The handle is used to specify
        /// the process in all functions that perform operations on the process
        /// object.
        /// </summary>
        public IntPtr Process;

        /// <summary>
        /// Handle to the primary thread of the newly created process. The
        /// handle is used to specify the thread in all functions that perform
        /// operations on the thread object.
        /// </summary>
        public IntPtr Thread;

        /// <summary>
        /// Value that can be used to identify a process. The value is valid
        /// from the time the process is created until the time the process is
        /// terminated.
        /// </summary>
        public uint ProcessId;

        /// <summary>
        /// Value that can be used to identify a thread. The value is valid from
        /// the time the thread is created until the time the thread is
        /// terminated.
        /// </summary>
        public uint ThreadId;
    }
}
