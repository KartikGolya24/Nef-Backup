//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder.Embedded v13.7.0+eaea7a6
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Linq.Expressions;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Infrastructure.ModelsBuilder;
using Umbraco.Cms.Core;
using Umbraco.Extensions;

namespace Umbraco.Cms.Web.Common.PublishedModels
{
	/// <summary>Form Section Form Block</summary>
	[PublishedModel("formSectionFormBlock")]
	public partial class FormSectionFormBlock : PublishedElementModel
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.7.0+eaea7a6")]
		public new const string ModelTypeAlias = "formSectionFormBlock";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.7.0+eaea7a6")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.7.0+eaea7a6")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public new static IPublishedContentType GetModelContentType(IPublishedSnapshotAccessor publishedSnapshotAccessor)
			=> PublishedModelUtility.GetModelContentType(publishedSnapshotAccessor, ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.7.0+eaea7a6")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(IPublishedSnapshotAccessor publishedSnapshotAccessor, Expression<Func<FormSectionFormBlock, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(publishedSnapshotAccessor), selector);
#pragma warning restore 0109

		private IPublishedValueFallback _publishedValueFallback;

		// ctor
		public FormSectionFormBlock(IPublishedElement content, IPublishedValueFallback publishedValueFallback)
			: base(content, publishedValueFallback)
		{
			_publishedValueFallback = publishedValueFallback;
		}

		// properties

		///<summary>
		/// After Success Redirection Button
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.7.0+eaea7a6")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("afterSuccessRedirectionButton")]
		public virtual global::Umbraco.Cms.Core.Models.Link AfterSuccessRedirectionButton => this.Value<global::Umbraco.Cms.Core.Models.Link>(_publishedValueFallback, "afterSuccessRedirectionButton");

		///<summary>
		/// Button Text Italic
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.7.0+eaea7a6")]
		[ImplementPropertyType("buttonTextItalic")]
		public virtual bool ButtonTextItalic => this.Value<bool>(_publishedValueFallback, "buttonTextItalic");

		///<summary>
		/// Description Text
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.7.0+eaea7a6")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("descriptionText")]
		public virtual global::Umbraco.Cms.Core.Strings.IHtmlEncodedString DescriptionText => this.Value<global::Umbraco.Cms.Core.Strings.IHtmlEncodedString>(_publishedValueFallback, "descriptionText");

		///<summary>
		/// Form
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.7.0+eaea7a6")]
		[ImplementPropertyType("form")]
		public virtual global::System.Nullable<global::System.Guid> Form => this.Value<global::System.Nullable<global::System.Guid>>(_publishedValueFallback, "form");

		///<summary>
		/// Heading Text
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.7.0+eaea7a6")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("headingText")]
		public virtual string HeadingText => this.Value<string>(_publishedValueFallback, "headingText");

		///<summary>
		/// Submit Button Border Color
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.7.0+eaea7a6")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("submitButtonBorderColor")]
		public virtual string SubmitButtonBorderColor => this.Value<string>(_publishedValueFallback, "submitButtonBorderColor");

		///<summary>
		/// Submit Button Theme
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.7.0+eaea7a6")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("submitButtonTheme")]
		public virtual string SubmitButtonTheme => this.Value<string>(_publishedValueFallback, "submitButtonTheme");

		///<summary>
		/// Success Message
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.7.0+eaea7a6")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("successMessage")]
		public virtual global::Umbraco.Cms.Core.Strings.IHtmlEncodedString SuccessMessage => this.Value<global::Umbraco.Cms.Core.Strings.IHtmlEncodedString>(_publishedValueFallback, "successMessage");

		///<summary>
		/// Success Message Icon
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.7.0+eaea7a6")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("successMessageIcon")]
		public virtual global::Umbraco.Cms.Core.Models.MediaWithCrops SuccessMessageIcon => this.Value<global::Umbraco.Cms.Core.Models.MediaWithCrops>(_publishedValueFallback, "successMessageIcon");
	}
}
