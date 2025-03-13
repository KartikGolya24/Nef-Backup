//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder.Embedded v13.7.1+5b54bed
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
	// Mixin Content Type with alias "sEOControls"
	/// <summary>SEO Controls</summary>
	public partial interface ISEocontrols : IPublishedElement
	{
		/// <summary>Meta Description</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.7.1+5b54bed")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		string MetaDescription { get; }

		/// <summary>Meta Title</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.7.1+5b54bed")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		string MetaTitle { get; }
	}

	/// <summary>SEO Controls</summary>
	[PublishedModel("sEOControls")]
	public partial class SEocontrols : PublishedElementModel, ISEocontrols
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.7.1+5b54bed")]
		public new const string ModelTypeAlias = "sEOControls";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.7.1+5b54bed")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.7.1+5b54bed")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public new static IPublishedContentType GetModelContentType(IPublishedSnapshotAccessor publishedSnapshotAccessor)
			=> PublishedModelUtility.GetModelContentType(publishedSnapshotAccessor, ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.7.1+5b54bed")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(IPublishedSnapshotAccessor publishedSnapshotAccessor, Expression<Func<SEocontrols, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(publishedSnapshotAccessor), selector);
#pragma warning restore 0109

		private IPublishedValueFallback _publishedValueFallback;

		// ctor
		public SEocontrols(IPublishedElement content, IPublishedValueFallback publishedValueFallback)
			: base(content, publishedValueFallback)
		{
			_publishedValueFallback = publishedValueFallback;
		}

		// properties

		///<summary>
		/// Meta Description
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.7.1+5b54bed")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("metaDescription")]
		public virtual string MetaDescription => GetMetaDescription(this, _publishedValueFallback);

		/// <summary>Static getter for Meta Description</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.7.1+5b54bed")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public static string GetMetaDescription(ISEocontrols that, IPublishedValueFallback publishedValueFallback) => that.Value<string>(publishedValueFallback, "metaDescription");

		///<summary>
		/// Meta Title
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.7.1+5b54bed")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("metaTitle")]
		public virtual string MetaTitle => GetMetaTitle(this, _publishedValueFallback);

		/// <summary>Static getter for Meta Title</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.7.1+5b54bed")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public static string GetMetaTitle(ISEocontrols that, IPublishedValueFallback publishedValueFallback) => that.Value<string>(publishedValueFallback, "metaTitle");
	}
}
