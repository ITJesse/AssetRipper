﻿using AssetRipper.Assets.Bundles;

namespace AssetRipper.Assets.Collections;

/// <summary>
/// A collection of artificial assets.
/// </summary>
public abstract class VirtualAssetCollection : AssetCollection
{
	protected VirtualAssetCollection(Bundle bundle) : base(bundle)
	{
	}

	public T CreateAsset<T>(int classID, Func<AssetInfo, T> factory) where T : IUnityObjectBase
	{
		AssetInfo assetInfo = CreateAssetInfo(classID);
		T instance = factory(assetInfo);
		m_assets.Add(instance.PathID, instance);
		return instance;
	}

	private AssetInfo CreateAssetInfo(int classID)
	{
		return new AssetInfo(this, ++m_nextId, classID);
	}

	private long m_nextId;
}
