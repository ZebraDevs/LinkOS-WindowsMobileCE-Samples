﻿/********************************************** 
 * CONFIDENTIAL AND PROPRIETARY 
 *
 * The source code and other information contained herein is the confidential and the exclusive property of
 * ZIH Corp. and is subject to the terms and conditions in your end user license agreement.
 * This source code, and any other information contained herein, shall not be copied, reproduced, published, 
 * displayed or distributed, in whole or in part, in any medium, by any means, for any purpose except as
 * expressly permitted under such license agreement.
 * 
 * Copyright ZIH Corp. 2010
 *
 * ALL RIGHTS RESERVED 
 ***********************************************
 File:   Program.cs

 Description: Entry point for IP Connection application. Runs an IPConnectionForm.

 $Revision: 1 $
 $Date: 2010/06/04 $
 *******************************************************************************/

using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace IP_Connection
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            Application.Run(new IPConnectionForm());
        }
    }
}