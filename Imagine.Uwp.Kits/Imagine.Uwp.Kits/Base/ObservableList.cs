﻿// ******************************************************************
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

using Imagine.Uwp.Kits.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Data;

namespace Imagine.Uwp.Kits.Base
{
    public abstract class ObservableList<T> : ObservableCollection<T>, ISupportIncrementalLoading
    {
        public bool HasMoreItems { get; set; } = true;
        
        private bool busy = false;

        public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
        {
            if (busy)
            {
                // Need to test this case
                throw new InvalidOperationException("Only one operation in flight at a time");
            }

            busy = true;

            return AsyncInfo.Run((c) => LoadMoreItems(count));
        }
        
        async Task<LoadMoreItemsResult> LoadMoreItems(uint count)
        {
            try
            {
                var items = await LoadMore(count);

                if (items != null && items.Any())
                {
                    foreach (var item in items)
                    {
                        this.Add(item);
                    }
                    Page++;
                }
                else
                {
                    HasMoreItems = false;
                }
                
                return new LoadMoreItemsResult { Count = (uint)items.Count() };
            }
            finally
            {
                busy = false;
            }
        }

        bool IsLoaded { get; set; } = false;

        int Page { get; set; } = 1;

        public int Size { get; set; } = 20;

        public async Task Load(Action completed = null) {
            if (!IsLoaded) {
               await Refresh(completed);
                IsLoaded = true;
            }
        }

        public async Task<IEnumerable<T>> LoadMore(uint size) {
            return await this.LoadMore(Page, size);
        }

        public abstract Task<IEnumerable<T>> LoadMore(int page, uint size);

        public async Task Refresh(Action completed = null) {

            var items = await this.LoadMore(1, (uint)Size);

            if (items == null || !items.Any())
                return;

            Page = 1;

            var firstItemOfRealData = items.FirstOrDefault();
            var firstItemOfList = items.FirstOrDefault();

            if (firstItemOfList != null && firstItemOfRealData != null && firstItemOfRealData.GetHashCode() != firstItemOfRealData.GetHashCode()) {
                this.Clear();

                foreach (var item in items)
                {
                    this.Add(item);
                }
            }
            
            if (completed != null)
                completed();
        }
    }
}
