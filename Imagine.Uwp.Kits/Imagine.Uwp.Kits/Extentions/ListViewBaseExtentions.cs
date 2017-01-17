// ******************************************************************
// Copyright (c) 2017 by Nguyen Pham. All rights reserved.
// This code is licensed under the MIT License (MIT).
// THE CODE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH
// THE CODE OR THE USE OR OTHER DEALINGS IN THE CODE.
// ******************************************************************


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Imagine.Uwp.Kits.Extentions
{
    public static class ListViewBaseExtentions
    {
        /// <summary>
        /// Scrolls the list to bring the specified data item into view. Đây là hàm đã gọi thêm hàm UpdateLayout() trước khi gọi hàm ScrollIntoView(...)
        /// </summary>
        /// <param name="currentListView"></param>
        /// <param name="index">Vị trí của phần tử sẽ scroll tới trong list</param>
        /// <returns>Return True nếu scroll thành công, ngược lại return False.</returns>
        public static void BringIntoView(this ListViewBase currentListView, object item)
        {
            currentListView.UpdateLayout();
            currentListView.ScrollIntoView(item, ScrollIntoViewAlignment.Leading);
        }
    }
}
