﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DistriqtConf.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("DistriqtConf.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;extensions&gt;
        ///	&lt;extensionID&gt;com.distriqt.Adverts&lt;/extensionID&gt;
        ///	&lt;extensionID&gt;com.distriqt.Core&lt;/extensionID&gt;
        ///
        ///	&lt;extensionID&gt;com.distriqt.playservices.Base&lt;/extensionID&gt;
        ///	&lt;extensionID&gt;com.distriqt.playservices.Ads&lt;/extensionID&gt;
        ///	&lt;extensionID&gt;com.distriqt.playservices.AdsIdentifier&lt;/extensionID&gt;
        ///
        ///	&lt;extensionID&gt;androidx.appcompat&lt;/extensionID&gt;
        ///	&lt;extensionID&gt;androidx.browser&lt;/extensionID&gt;
        ///	&lt;extensionID&gt;androidx.core&lt;/extensionID&gt;
        ///	&lt;extensionID&gt;androidx.constraintlayout&lt;/extensionID&gt;
        ///	&lt;extensionID&gt;and [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Adverts {
            get {
                return ResourceManager.GetString("Adverts", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;manifest android:installLocation=&quot;auto&quot;&gt;
        ///	
        ///	&lt;!--Required. Used to access the Internet to make ad requests--&gt;
        ///	&lt;uses-permission android:name=&quot;android.permission.INTERNET&quot;/&gt;
        ///
        ///	&lt;!--Optional. Used to check if an internet connection is available prior to making an ad request.--&gt;
        ///	&lt;uses-permission android:name=&quot;android.permission.ACCESS_NETWORK_STATE&quot;/&gt;
        ///
        ///	&lt;application 
        ///		android:hardwareAccelerated=&quot;true&quot;
        ///		android:appComponentFactory=&quot;androidx.core.app.CoreComponentFactory&quot;&gt;
        ///
        ///		&lt;meta-data android:na [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string AdvertsManifest {
            get {
                return ResourceManager.GetString("AdvertsManifest", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;extensions&gt;
        ///    &lt;extensionID&gt;com.distriqt.Application&lt;/extensionID&gt;
        ///    &lt;extensionID&gt;com.distriqt.Core&lt;/extensionID&gt;
        ///    &lt;extensionID&gt;androidx.core&lt;/extensionID&gt;
        ///&lt;/extensions&gt;.
        /// </summary>
        internal static string Application {
            get {
                return ResourceManager.GetString("Application", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;manifest android:installLocation=&quot;auto&quot;&gt;
        ///    &lt;uses-permission android:name=&quot;android.permission.INTERNET&quot;/&gt;
        ///    &lt;uses-permission android:name=&quot;android.permission.READ_PHONE_STATE&quot;/&gt;
        ///    &lt;uses-permission android:name=&quot;android.permission.WAKE_LOCK&quot; /&gt;
        ///    &lt;uses-permission android:name=&quot;android.permission.RECEIVE_BOOT_COMPLETED&quot; /&gt;
        ///
        ///    &lt;application&gt;
        ///        
        ///        &lt;!-- AUTO START and ALARM MANAGER --&gt;
        ///        &lt;receiver android:enabled=&quot;true&quot;
        ///            android:name=&quot;com.distriqt.extension.applica [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string ApplicationManifest {
            get {
                return ResourceManager.GetString("ApplicationManifest", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 	&lt;manifest android:installLocation=&quot;auto&quot;&gt;
        ///		&lt;uses-permission android:name=&quot;android.permission.INTERNET&quot;/&gt;
        ///		&lt;uses-permission android:name=&quot;android.permission.FOREGROUND_SERVICE&quot; /&gt;
        ///
        ///		&lt;application&gt;
        ///
        ///			&lt;!-- com.google.android.play --&gt;
        ///			&lt;activity
        ///				android:name=&quot;com.google.android.play.core.missingsplits.PlayCoreMissingSplitsActivity&quot;
        ///				android:enabled=&quot;false&quot;
        ///				android:exported=&quot;false&quot;
        ///				android:launchMode=&quot;singleInstance&quot;
        ///				android:process=&quot;:playcore_missing_splits_activity&quot;
        ///				a [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string ApplicationRateManifest {
            get {
                return ResourceManager.GetString("ApplicationRateManifest", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;extensions&gt;
        ///	&lt;extensionID&gt;com.distriqt.ApplicationRater&lt;/extensionID&gt;
        ///	&lt;extensionID&gt;com.distriqt.Core&lt;/extensionID&gt;
        ///	&lt;extensionID&gt;com.google.android.play&lt;/extensionID&gt;
        ///&lt;/extensions&gt;.
        /// </summary>
        internal static string ApplicationRater {
            get {
                return ResourceManager.GetString("ApplicationRater", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;manifest android:installLocation=&quot;auto&quot; &gt;
        ///  &lt;uses-sdk android:minSdkVersion=&quot;19&quot;/&gt;
        ///		&lt;uses-sdk android:targetSdkVersion=&quot;29&quot;/&gt;
        ///  &lt;uses-permission android:name=&quot;android.permission.INTERNET&quot;/&gt;
        ///  &lt;uses-permission android:name=&quot;android.permission.ACCESS_NETWORK_STATE&quot;/&gt;
        ///	&lt;uses-permission android:name=&quot;android.permission.WRITE_EXTERNAL_STORAGE&quot; /&gt;
        ///  &lt;uses-permission android:name=&quot;com.android.vending.BILLING&quot;/&gt;
        ///&lt;/manifest&gt;.
        /// </summary>
        internal static string CommonManifest {
            get {
                return ResourceManager.GetString("CommonManifest", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;extensions&gt;
        ///	&lt;extensionID&gt;com.distriqt.FacebookAPI&lt;/extensionID&gt;
        ///	&lt;extensionID&gt;com.distriqt.Core&lt;/extensionID&gt;
        ///	
        ///	&lt;extensionID&gt;com.distriqt.Bolts&lt;/extensionID&gt;
        ///
        ///	&lt;extensionID&gt;com.distriqt.playservices.Base&lt;/extensionID&gt;
        ///	&lt;extensionID&gt;com.distriqt.playservices.Auth&lt;/extensionID&gt;
        ///
        ///	&lt;extensionID&gt;androidx.appcompat&lt;/extensionID&gt;
        ///	&lt;extensionID&gt;androidx.browser&lt;/extensionID&gt;
        ///	&lt;extensionID&gt;androidx.cardview&lt;/extensionID&gt;
        ///	&lt;extensionID&gt;androidx.core&lt;/extensionID&gt;
        ///	&lt;extensionID&gt;androidx.recyclerview&lt;/e [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Facebook {
            get {
                return ResourceManager.GetString("Facebook", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;manifest android:installLocation=&quot;auto&quot;&gt;
        ///	&lt;uses-permission android:name=&quot;android.permission.INTERNET&quot;/&gt;
        ///	&lt;uses-permission android:name=&quot;android.permission.WRITE_EXTERNAL_STORAGE&quot;/&gt;
        ///
        ///	&lt;application android:name=&quot;androidx.multidex.MultiDexApplication&quot;&gt;
        ///		&lt;meta-data android:name=&quot;com.google.android.gms.version&quot; android:value=&quot;@integer/google_play_services_version&quot; /&gt;
        ///
        ///		&lt;intent-filter&gt;
        ///			&lt;action android:name=&quot;android.intent.action.MAIN&quot; /&gt;
        ///			&lt;category android:name=&quot;android.intent.category.LAUNCHER&quot;  [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string FacebookManifest {
            get {
                return ResourceManager.GetString("FacebookManifest", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;extensions&gt;
        ///    &lt;extensionID&gt;com.distriqt.GameServices&lt;/extensionID&gt;
        ///    &lt;extensionID&gt;com.distriqt.Core&lt;/extensionID&gt;
        ///    &lt;extensionID&gt;androidx.core&lt;/extensionID&gt;
        ///    &lt;extensionID&gt;androidx.appcompat&lt;/extensionID&gt;
        ///    &lt;extensionID&gt;com.distriqt.playservices.Base&lt;/extensionID&gt;
        ///    &lt;extensionID&gt;com.distriqt.playservices.Drive&lt;/extensionID&gt;
        ///    &lt;extensionID&gt;com.distriqt.playservices.Games&lt;/extensionID&gt;
        ///    &lt;extensionID&gt;com.distriqt.playservices.Auth&lt;/extensionID&gt;
        ///&lt;/extensions&gt;.
        /// </summary>
        internal static string GameService {
            get {
                return ResourceManager.GetString("GameService", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;manifest android:installLocation=&quot;auto&quot;&gt;
        ///	&lt;uses-permission android:name=&quot;android.permission.INTERNET&quot;/&gt;
        ///	
        ///	&lt;application&gt;
        ///		
        ///		&lt;meta-data android:name=&quot;com.google.android.gms.games.APP_ID&quot; android:value=&quot;\ XXXXXXXXXXXX&quot; /&gt;
        ///		&lt;meta-data android:name=&quot;com.google.android.gms.version&quot; android:value=&quot;@integer/google_play_services_version&quot; /&gt;
        ///
        ///		&lt;activity
        ///			android:name=&quot;com.google.android.gms.auth.api.signin.internal.SignInHubActivity&quot;
        ///			android:excludeFromRecents=&quot;true&quot;
        ///			android:exported=&quot;false&quot;        /// [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string GameSeviceManifest {
            get {
                return ResourceManager.GetString("GameSeviceManifest", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;extensions&gt;
        ///    &lt;extensionID&gt;com.distriqt.InAppBilling&lt;/extensionID&gt;
        ///    &lt;extensionID&gt;com.distriqt.Core&lt;/extensionID&gt;
        ///&lt;/extensions&gt;.
        /// </summary>
        internal static string InApp {
            get {
                return ResourceManager.GetString("InApp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;manifest android:installLocation=&quot;auto&quot;&gt;
        ///	&lt;uses-permission android:name=&quot;android.permission.INTERNET&quot;/&gt;
        ///	&lt;uses-permission android:name=&quot;com.android.vending.BILLING&quot; /&gt;
        ///
        ///	&lt;application&gt;
        ///
        ///		&lt;activity 
        ///			android:name=&quot;com.distriqt.extension.inappbilling.activities.ProductViewActivity&quot; 
        ///			android:theme=&quot;@android:style/Theme.Translucent.NoTitleBar&quot; /&gt;
        ///
        ///
        ///		&lt;!-- GOOGLE PLAY BILLING --&gt;
        ///		&lt;activity
        ///			android:name=&quot;com.android.billingclient.api.ProxyBillingActivity&quot;
        ///			android:configChanges=&quot;keyboar [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string InAppManifest {
            get {
                return ResourceManager.GetString("InAppManifest", resourceCulture);
            }
        }
    }
}
