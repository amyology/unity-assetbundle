using UnityEngine;
using System.Collections;
using AssetBundles;
using System;

public class LoadAsset : MonoBehaviour {

	public string BundleURL;
	public string AssetName;

	IEnumerator Start () {

		using (WWW www = new WWW(BundleURL)) {
			yield return www;
			if (www.error != null)
				throw new Exception("WWW download had an error:" + www.error);
			AssetBundle bundle = www.assetBundle;
			if (AssetName == "")
				Instantiate(bundle.mainAsset);
			else
				Instantiate(bundle.LoadAsset(AssetName));

			bundle.Unload(false);

		}
	}
}
