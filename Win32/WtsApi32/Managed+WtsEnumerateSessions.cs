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
using System.ComponentModel;

namespace Sudowin.Win32.WtsApi32
{
    public static partial class Managed
    {
        /// <summary>
        /// The WtsEnumerateSessions method retrieves
        /// a list of sessions on a specified terminal server.
        /// </summary>
        /// <param name="serverHandle">
        /// Handle to a terminal server.
        /// </param>
        /// <returns>
        /// An array of WtsSessionInfo structures containing
        /// information about the sessions on the terminal server.
        /// </returns>
        /// <remarks>
        /// This is the managed version of
        /// <see cref="Native.WtsEnumerateSessions">WtsEnumerateSessions</see>
        /// </remarks>
        /// <exception cref="Win32Exception" />
        public static WtsSessionInfo[] WtsEnumerateSessions(IntPtr serverHandle)
        {
            // pointer to pointer of where the SessionInfo
            // structures are
            IntPtr ppWsi = IntPtr.Zero;

            // number of structures that ppWsi
            // is pointing to

            // array of session info structures that
            // this method will return if all goes
            // according to plan
            WtsSessionInfo[] wsi = null;

            // try to enumerate the sessions on the server. if
            // the enumeration fails throw an exception with the
            // win32 error code.
            if (!Native.WtsEnumerateSessions(
                serverHandle, 0, 1, out ppWsi, out uint wsi_ct))
            {
                throw (new Win32Exception(Marshal.GetLastWin32Error()));
            }
            // marshal the return structures to a managed array
            // and return that array from ths method
            else
            {
                wsi = new WtsSessionInfo[wsi_ct];

#if WIN32
                int ppWsi_index = 0;
#else
                Int64 ppWsi_index = 0;
#endif

                // save the pointer to the original structure
                IntPtr ppWsi_original = ppWsi;

                try
                {
                    for (int i = 0; i < wsi.Length; i++)
                    {
                        wsi[i] = (WtsSessionInfo)Marshal.PtrToStructure(ppWsi, typeof(WtsSessionInfo));

                        // Whoo Hoo!  Pointer arithemetic!  I almost forgot how to do this.
#if WIN32
                        ppWsi_index = (int)(ppWsi) + Marshal.SizeOf(typeof(WtsSessionInfo));
#else
                        ppWsi_index = (Int64)(ppWsi) + Marshal.SizeOf(typeof(WtsSessionInfo));
#endif

                        // Get the location of the next structure.
                        ppWsi = (IntPtr)(ppWsi_index);
                    }
                }
                finally
                {
                    // Free the memory.
                    Native.WtsFreeMemory(ppWsi_original);
                }

                return wsi;
            }
        }
    }
}
