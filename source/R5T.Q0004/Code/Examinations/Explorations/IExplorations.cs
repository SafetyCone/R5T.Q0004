using System;

using Microsoft.Extensions.DependencyInjection;

using BlazorTemplater;

using R5T.D0118;
using R5T.D0118.I000;
using R5T.F0000;
using R5T.F0033;
using R5T.R0003;
using R5T.T0141;
using R5T.Z0015;


namespace R5T.Q0004
{
	[ExplorationsMarker]
	public partial interface IExplorations : IExplorationsMarker
	{
        /// <summary>
        /// Can BlazorTemplater handle a component with a component with child content?
        /// Result: YES!
        /// </summary>
        public void WhatAboutComponentWithComponentWithChildContent()
        {
            string html = new ComponentRenderer<Component09>()
                .Render();

            // Result:
            // <
            NotepadPlusPlusOperator.Instance.WriteTextAndOpen(
                FilePaths.Instance.OutputHtmlFilePath,
                html);
        }

        /// <summary>
        /// The IHtmlHelper.RenderComponentAsync() method cannot handle layouts, both components with layouts, and components with components with layouts.
        /// Can BlazorTemplater?
        /// Result: Yes (component with layout <see cref="Component06"/>), NO! (component with component with layout).
        /// </summary>
        public void WhatAboutComponentWithComponentWithLayout()
        {
            //string html = new ComponentRenderer<Component06>()
            string html = new ComponentRenderer<Component07>()
                .Render();

            // Result:
            // <
            NotepadPlusPlusOperator.Instance.WriteTextAndOpen(
                FilePaths.Instance.OutputHtmlFilePath,
                html);
        }

        /// <summary>
        /// What about asynchronous code? There is no RenderAsync() method, so can components that use asynchronous services be rendered?
        /// Result: NO! Asynchronous results cannot be handled.
        /// </summary>
        public void WhatAboutAsynchronous()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IServiceC, ServiceC01>()
                .BuildServiceProvider();

            string html = new ComponentRenderer<Component03>()
                .AddServiceProvider(serviceProvider)
                // No RenderAsync(). But can asynchronous components be rendered?
                .Render();

            // Result:
            // <
            NotepadPlusPlusOperator.Instance.WriteTextAndOpen(
                FilePaths.Instance.OutputHtmlFilePath,
                html);
        }

        /// <summary>
        /// What if no parameter is set?
        /// Result: works, just a blank where the value would be (depends on string type).
        /// </summary>
        public void NoParameterSet()
        {
            string html = new ComponentRenderer<Component02>()
                .Render();

            // Result:
            // <p>Hello from Component02!</p>
            // <p>Value: </p>
            Console.WriteLine(html);
        }

        /// <summary>
        /// Just try the BlazorTemplater library, on a simple component that has some complications (like parameters).
        /// </summary>
        public void SecondRender()
        {
            string html = new ComponentRenderer<Component02>()
                .Set(c => c.Value, "A value.")
                .Render();

            // Result:
            // <p>Hello from Component02!</p>
            // <p>Value: A value.</p>
            Console.WriteLine(html);
        }

        /// <summary>
        /// Just try the BlazorTemplater library, on an extremely simple component.
        /// </summary>
        public void FirstRender()
		{
            string html = new ComponentRenderer<Component01>()
				.Render();

            // Result:
            // <p>Hello from Component01!</p>
            Console.WriteLine(html);
        }
	}
}