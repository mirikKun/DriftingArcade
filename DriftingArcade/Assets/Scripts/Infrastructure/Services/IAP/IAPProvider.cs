﻿using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using UnityEngine;
using UnityEngine.Purchasing;
using Zenject;

namespace CodeBase.Services.IAP
{
  public class IAPProvider: IStoreListener
  {
    private const string IAPConfigsPath = "IAP/products";

    private IExtensionProvider _extensions;
    private IStoreController _controller;
    private IAPService _iapService;

    public Dictionary<string, ProductConfig> Configs { get; private set; }
    public Dictionary<string, Product> Products { get; private set; }


    public event Action Initialized;

    public bool IsInitialized
      => _controller != null && _extensions != null;


    public void Initialize(IAPService iapService)
    {
      _iapService = iapService; 
      
      Configs = new Dictionary<string, ProductConfig>();
      Products = new Dictionary<string, Product>();
      
      ConfigurationBuilder builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

      Load();

      foreach (ProductConfig productConfig in Configs.Values) 
        builder.AddProduct(productConfig.Id, productConfig.ProductType);

      UnityPurchasing.Initialize(this, builder);
    }

    public void StartPurchase(string productId) => 
      _controller.InitiatePurchase(productId);

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
      _extensions = extensions;
      _controller = controller;

      foreach (Product product in _controller.products.all) 
        Products.Add(product.definition.id, product);

      Initialized?.Invoke();
      
      Debug.Log("UnityPurchasing initialization success");
    }

    public void OnInitializeFailed(InitializationFailureReason error) => 
      Debug.Log($"UnityPurchasing OnInitializeFailed {error}");

    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
      Debug.Log($"UnityPurchasing OnInitializeFailed {error}");
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
    {
      Debug.Log($"UnityPurchasing ProcessPurchase {purchaseEvent.purchasedProduct.definition.id} success");
      return _iapService.ProcessPurchase(purchaseEvent.purchasedProduct);
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason) => 
      Debug.LogError($"Product {product.definition.id} purchase failed, reason - {failureReason}, transaction id - {product.transactionID}");

    private void Load() =>
      Configs = Resources
        .Load<TextAsset>(IAPConfigsPath)
        .text
        .ToDeserialized<ProductConfigWrapper>()
        .Configs
        .ToDictionary(x => x.Id, x => x);
  }
}