using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bz04.Pages
{
    public partial class Bz04AComponent : Microsoft.AspNetCore.Components.ComponentBase
    {
        /// <summary>
        /// 這裡將會重新產生出最新狀態的轉譯樹
        /// </summary>
        /// <param name="__builder"></param>
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            Console.WriteLine($"   子元件轉譯中 BuildRenderTree");
            __builder.AddMarkupContent(0, "<h3>Counter - 使用基本型別參數子元件</h3>\r\n\r\n");
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
        [Parameter]
        public int currentCount { get; set; } = 0;

        private void IncrementCount()
        {
            Console.WriteLine($"   子元件 觸發按鈕事件 IncrementCount");
            currentCount++;
        }
        protected override bool ShouldRender()
        {
            Console.WriteLine($"   子元件 執行 ShouldRender");
            return base.ShouldRender();
        }
    }
}
