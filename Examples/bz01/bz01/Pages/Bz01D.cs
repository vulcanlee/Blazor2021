using System;
using System.Threading.Tasks;

namespace bz01.Pages
{
    [Microsoft.AspNetCore.Components.RouteAttribute("/Bz01D")]
    public partial class Bz01D : Microsoft.AspNetCore.Components.ComponentBase
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
                .Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, IncrementCount1Async));
            __builder.AddContent(8, "Click me(一次等待)");
            __builder.CloseElement();
            __builder.OpenElement(9, "button");
            __builder.AddAttribute(10, "class", "btn btn-primary");
            __builder.AddAttribute(11, "onclick", Microsoft.AspNetCore.Components.EventCallback
                .Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, IncrementCount2Async));
            __builder.AddContent(12, "Click me(多次等待)");
            __builder.CloseElement();
        }

        int currentCount { get; set; } = 0;

        private async Task IncrementCount1Async()
        {
            Console.WriteLine($"觸發按鈕事件 IncrementCount1Async");
            currentCount++;
            await Task.Delay(1000);
            currentCount++;
        }

        private async Task IncrementCount2Async()
        {
            Console.WriteLine($"觸發按鈕事件 IncrementCount2Async");
            currentCount++;
            await Task.Delay(1000);
            currentCount++;
            await Task.Delay(1000);
            currentCount++;
            await Task.Delay(1000);
            currentCount++;
        }
        protected override bool ShouldRender()
        {
            Console.WriteLine($"執行 ShouldRender");
            return base.ShouldRender();
        }
    }
}
