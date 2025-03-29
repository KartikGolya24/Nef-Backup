//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder.Embedded v13.7.2+fd5b8de
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
	/// <summary>Electricity Purchase</summary>
	[PublishedModel("electricityPurchase")]
	public partial class ElectricityPurchase : PurchaseFlow, IPurchaseFlowThankYouSection
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.7.2+fd5b8de")]
		public new const string ModelTypeAlias = "electricityPurchase";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.7.2+fd5b8de")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.7.2+fd5b8de")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public new static IPublishedContentType GetModelContentType(IPublishedSnapshotAccessor publishedSnapshotAccessor)
			=> PublishedModelUtility.GetModelContentType(publishedSnapshotAccessor, ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.7.2+fd5b8de")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(IPublishedSnapshotAccessor publishedSnapshotAccessor, Expression<Func<ElectricityPurchase, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(publishedSnapshotAccessor), selector);
#pragma warning restore 0109

		private IPublishedValueFallback _publishedValueFallback;

		// ctor
		public ElectricityPurchase(IPublishedContent content, IPublishedValueFallback publishedValueFallback)
			: base(content, publishedValueFallback)
		{
			_publishedValueFallback = publishedValueFallback;
		}

		// properties

		///<summary>
		/// Address Types
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.7.2+fd5b8de")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("addressTypes")]
		public virtual global::System.Collections.Generic.IEnumerable<string> AddressTypes => this.Value<global::System.Collections.Generic.IEnumerable<string>>(_publishedValueFallback, "addressTypes");

		///<summary>
		/// Billing Types
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.7.2+fd5b8de")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("billingTypes")]
		public virtual global::Umbraco.Cms.Core.Models.Blocks.BlockListModel BillingTypes => this.Value<global::Umbraco.Cms.Core.Models.Blocks.BlockListModel>(_publishedValueFallback, "billingTypes");

		///<summary>
		/// Postpaid Payment Description
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.7.2+fd5b8de")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("postpaidPaymentDescription")]
		public virtual global::Umbraco.Cms.Core.Strings.IHtmlEncodedString PostpaidPaymentDescription => this.Value<global::Umbraco.Cms.Core.Strings.IHtmlEncodedString>(_publishedValueFallback, "postpaidPaymentDescription");

		///<summary>
		/// Prepaid Payment Description
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.7.2+fd5b8de")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("prepaidPaymentDescription")]
		public virtual global::Umbraco.Cms.Core.Strings.IHtmlEncodedString PrepaidPaymentDescription => this.Value<global::Umbraco.Cms.Core.Strings.IHtmlEncodedString>(_publishedValueFallback, "prepaidPaymentDescription");

		///<summary>
		/// Button
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.7.2+fd5b8de")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("button")]
		public virtual global::Umbraco.Cms.Core.Models.Link Button => global::Umbraco.Cms.Web.Common.PublishedModels.PurchaseFlowThankYouSection.GetButton(this, _publishedValueFallback);

		///<summary>
		/// Button Border color
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.7.2+fd5b8de")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("buttonBorderColor")]
		public virtual string ButtonBorderColor => global::Umbraco.Cms.Web.Common.PublishedModels.PurchaseFlowThankYouSection.GetButtonBorderColor(this, _publishedValueFallback);

		///<summary>
		/// Button Theme
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.7.2+fd5b8de")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("buttonTheme")]
		public virtual string ButtonTheme => global::Umbraco.Cms.Web.Common.PublishedModels.PurchaseFlowThankYouSection.GetButtonTheme(this, _publishedValueFallback);

		///<summary>
		/// Heading
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.7.2+fd5b8de")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("heading")]
		public virtual string Heading => global::Umbraco.Cms.Web.Common.PublishedModels.PurchaseFlowThankYouSection.GetHeading(this, _publishedValueFallback);

		///<summary>
		/// Position Images
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.7.2+fd5b8de")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("positionImages")]
		public virtual global::Umbraco.Cms.Core.Models.Blocks.BlockListModel PositionImages => global::Umbraco.Cms.Web.Common.PublishedModels.PurchaseFlowThankYouSection.GetPositionImages(this, _publishedValueFallback);

		///<summary>
		/// Success Description
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.7.2+fd5b8de")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("successDescription")]
		public virtual global::Umbraco.Cms.Core.Strings.IHtmlEncodedString SuccessDescription => global::Umbraco.Cms.Web.Common.PublishedModels.PurchaseFlowThankYouSection.GetSuccessDescription(this, _publishedValueFallback);

		///<summary>
		/// Success Icon
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.7.2+fd5b8de")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("successIcon")]
		public virtual global::Umbraco.Cms.Core.Models.MediaWithCrops SuccessIcon => global::Umbraco.Cms.Web.Common.PublishedModels.PurchaseFlowThankYouSection.GetSuccessIcon(this, _publishedValueFallback);

		///<summary>
		/// Success Title
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.7.2+fd5b8de")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("successTitle")]
		public virtual string SuccessTitle => global::Umbraco.Cms.Web.Common.PublishedModels.PurchaseFlowThankYouSection.GetSuccessTitle(this, _publishedValueFallback);
	}
}
