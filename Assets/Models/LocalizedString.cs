using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizedString {
    public string languageCode { get; set; }
    public string str { get; set; }

	public static string GetLocalizedString(string langugeCode, LocalizedString[] localizedStrings) {

		for (int i = 0; i < localizedStrings.Length; i++) {
			if(localizedStrings[i].languageCode.Equals(langugeCode))
				return localizedStrings[i].str;
			}
		return localizedStrings [0].str;
	}
}
