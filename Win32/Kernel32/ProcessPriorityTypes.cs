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

namespace Sudowin.Win32.Kernel32
{
    /// <summary>
    /// Priority type of a process.
    /// </summary>
    /// <remarks>
    /// https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-getpriorityclass
    /// </remarks>
    [Flags]
    public enum ProcessPriorityFlags : uint
    {
        /// <summary>
        /// Process that has priority above Normal but below High.
        /// </summary>
        /// <remarks>
        /// Windows NT and Windows Me/98/95:  This value is not supported.
        /// </remarks>
        AboveNormal = 0x00008000,
        /// <summary>
        ///  Process that has priority above Idle but below Normal.
        /// </summary>
        /// <remarks>
        /// Windows NT and Windows Me/98/95:  This value is not supported.
        /// </remarks>
        BelowNormal = 0x00004000,
        /// <summary>
        /// Process that performs time-critical tasks that must be executed
        /// immediately for it to run correctly. The threads of a high-priority class
        /// process preempt the threads of normal or idle priority class processes.
        /// An example is the Task List, which must respond quickly when called by the user,
        /// regardless of the load on the operating system. Use extreme care when
        /// using the high-priority class, because a high-priority class CPU-bound application
        /// can use nearly all available cycles.
        /// </summary>
        High = 0x00000080,
        /// <summary>
        /// Process whose threads run only when the system is idle and are preempted by
        /// the threads of any process running in a higher priority class. An example is a
        /// screen saver. The idle priority class is inherited by child processes.
        /// </summary>
        Idle = 0x00000040,
        /// <summary>
        /// Process with no special scheduling needs.
        /// </summary>
        Normal = 0x00000020,
        /// <summary>
        /// Process that has the highest possible priority. The threads of a real-time
        /// priority class process preempt the threads of all other processes, including
        /// operating system processes performing important tasks. For example, a real-time
        /// process that executes for more than a very brief interval can cause disk caches
        /// not to flush or cause the mouse to be unresponsive.
        /// </summary>
        Realtime = 0x00000100,
    }
}
