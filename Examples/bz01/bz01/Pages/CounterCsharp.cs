﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace bz01.Pages
{
    public partial class CounterCsharp : Microsoft.AspNetCore.Components.ComponentBase
    {
        /// <summary>
        /// 這裡將會重新產生出最新狀態的轉譯樹
        /// </summary>
        /// <param name="__builder"></param>
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            Console.WriteLine($"BuildRenderTree {DateTime.Now}");
            __builder.AddMarkupContent(0, "<h3>Counter - 使用 C# 來設計元件</h3>\r\n\r\n");
            __builder.OpenElement(1, "p");
            __builder.AddContent(2, "Current count: ");
            __builder.AddContent(3,
                   currentCount
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(4, "\r\n\r\n");
            __builder.OpenElement(5, "button");
            __builder.AddAttribute(6, "class", "btn btn-primary");
            __builder.AddAttribute(7, "onclick", Microsoft.AspNetCore.Components.EventCallback
                .Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, IncrementCount));
            __builder.AddContent(8, "Click me");
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\r\n\r\n");
            __builder.OpenElement(10, "button");
            __builder.AddAttribute(11, "class", "btn btn-secondary");
            __builder.AddAttribute(12, "onclick", Microsoft.AspNetCore.Components.EventCallback
                .Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, OnlyTesting));
            __builder.AddContent(13, "沒做任何事情");
            __builder.CloseElement();
        }

        int currentCount { get; set; } = 0;

        private void IncrementCount()
        {
            Console.WriteLine($"IncrementCount {DateTime.Now}");
            currentCount++;
            StateHasChanged();
            StateHasChanged();
            StateHasChanged();
            StateHasChanged();
        }

        private async Task OnlyTesting()
        {
            currentCount--;
            #region 檢查執行緒同步內容是否存在
            var sc = SynchronizationContext.Current == null ? "無 SC" : "有SC";
            Console.WriteLine($"Thread Id:{Thread.CurrentThread.ManagedThreadId} {sc}");
            #endregion

            Console.WriteLine($"OnlyTesting before await 1 {DateTime.Now}");
            await Task.Delay(100).ConfigureAwait(false);
            Console.WriteLine($"OnlyTesting after await 1 {DateTime.Now}");
            currentCount--;

            #region 檢查執行緒同步內容是否存在
            sc = SynchronizationContext.Current == null ? "無 SC" : "有SC";
            Console.WriteLine($"Thread Id:{Thread.CurrentThread.ManagedThreadId} {sc}");
            #endregion

            Console.WriteLine($"OnlyTesting before await 2 {DateTime.Now}");
            await Task.Delay(100);

            #region 檢查執行緒同步內容是否存在
            sc = SynchronizationContext.Current == null ? "無 SC" : "有SC";
            Console.WriteLine($"Thread Id:{Thread.CurrentThread.ManagedThreadId} {sc}");
            #endregion

            currentCount--;
            Console.WriteLine($"OnlyTesting after await 2 {DateTime.Now}");
            currentCount--;
            StateHasChanged();
        }
        protected override bool ShouldRender()
        {
            Console.WriteLine($"ShouldRender {DateTime.Now}");
            return base.ShouldRender();
        }
    }
}
