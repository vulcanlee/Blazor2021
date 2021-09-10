using System;
using System.Threading;
using System.Threading.Tasks;

namespace bz01.Pages
{
    [Microsoft.AspNetCore.Components.RouteAttribute("/Bz01F")]
    public partial class Bz01F : Microsoft.AspNetCore.Components.ComponentBase
    {
        /// <summary>
        /// 這裡將會重新產生出最新狀態的轉譯樹
        /// </summary>
        /// <param name="__builder"></param>
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            Console.WriteLine($"元件轉譯中 BuildRenderTree");
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
        }

        int currentCount { get; set; } = 0;

        private void IncrementCount()
        {
            Console.WriteLine($"觸發按鈕事件 IncrementCount");
            currentCount++;
            var task = Task.Run(() =>
            {
                var sc = SynchronizationContext.Current;
                var scMsg = sc == null ? "同步內容不存在" : "同步內容存在";
                Console.WriteLine($"{scMsg}");
                //Thread.Sleep(1000);
                //await Task.Delay(1000);
                //sc = SynchronizationContext.Current;
                //scMsg = sc == null ? "同步內容不存在" : "同步內容存在";
                //Console.WriteLine($"{scMsg}");
                currentCount++;
                StateHasChanged();
            });
        }
        //private void IncrementCount()
        //{
        //    Console.WriteLine($"觸發按鈕事件 IncrementCount");
        //    currentCount++;
        //    var task = Task.Run(async () =>
        //    {
        //        var sc = SynchronizationContext.Current;
        //        var scMsg = sc == null ? "同步內容不存在" : "同步內容存在";
        //        Console.WriteLine($"{scMsg}");
        //        //Thread.Sleep(1000);
        //        await Task.Delay(1000);
        //        //sc = SynchronizationContext.Current;
        //        //scMsg = sc == null ? "同步內容不存在" : "同步內容存在";
        //        //Console.WriteLine($"{scMsg}");
        //        currentCount++;
        //        StateHasChanged();
        //    });
        //}
        protected override bool ShouldRender()
        {
            Console.WriteLine($"執行 ShouldRender");
            return base.ShouldRender();
        }
    }
}
