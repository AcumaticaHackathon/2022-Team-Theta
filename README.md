# 2022-Team-Theta

Acumatica Centurion

With Acumatica Centurion, keep your guard up against malicious and unsavory files and raise an alarm when enemies attack.  Whether originating via standard screens, 3rd part web service applications, or the Acumatica Mobile app, the Acumatica Centurion never lets down its guard.

There are 3 software components to this project.

  • TeamTheta Customization Project (with source code)
  
    o Contains TT Preferences screen for the API key
    
    o Contains the File Data Entry screen for the 3rd party uploader
    
    o Contains Mobile Screen definitions to add a basic Stock Items (IN202500) screen to mobile with an action for attachments

    o Contains Business Event, Notication Template, and Generic Inquiry for Notification when NSFW image detected

  • DataMigrationApp (standalone 3rd party application to send files to Acumatica via web services)
  
  • Cloudmersive (https://cloudmersive.com/) 
  
    o Cloudmersive.APIClient.NET.ImageRecognition
    
    o Cloudmersive.APIClient.NET.VirusScan
    
    
*** The team project file are located under the 2021R2 branch ***


Installation:

Prerequisite: Acumatica 2021R2 (21.206.0018)

The Cloudmersive nuget packages automatically install/upgrade NewtonSoft JSON and RestSharp.  Due to the popularity of these packages, they were not included in the customization project and should be copied to the instance bin folder if missing or older.

Import and publish the TeamTheta customization project.  Alternatively, if recreating this project, install the nuget packages noted above in the Cloudmersive software component.

Create a Cloudmersive account and select the FREE plan for the ability to make 800 calls per month at a rate limit of 1 call per second.  This makes the demo run slowly due to multiple calls, but it allows testing and demo without added cost.

Copy the Cloudmersive API key and open the TT Preferences screen in the Theta workspace in Acumatica.  Paste the API key into the API Key field and save.  When the cap of 800 calls has been reached, this allows changing to a new key for another account easily.

For the 3rd party mass file upload, copy the DataMigrationApp to your local PC and run DataMigrationApp.exe to run the tool.  Replace the default connection strings and select a folder with attachments to upload.  Press the upload button to execute.  Note that the TeamTheta project makes 1 to 8 calls per file depending on the file type as to what processing has been programmed to be performed.  Therefore, uploading 100 png files, for instance, will consume the entire use of the free cloudmersive monthly allotment of API calls.
