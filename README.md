# Rocksmith custom DLC updater
An unofficial rocksmith 2014 custom dlc updater. This application can keep track of updates for your Rocksmith 2014 custom DLC songs from customsforge.com.

## Disclaimer
Use this application at your own risk, I can not be held responsible for any damage to your pc.
Me and this application itself are not affiliated with customsforge in any way.

## Installing
Download the files from the bin/ directory and store them wherever you want.
Start the application by double clicking the executable.

## Features
- Identifying your custom songs from customsforge.com
- Checking for version updates of your custom songs

## How to use
1. Open the application
2. Select your Rocksmith 2014 dlc directory
3. Let the application scan your songs
4. Before the next step gets executed, you probably have to login into your customsforge account. No data is stored, this is only done because we need to access the customsforge pages so we can find information about the songs.
4. You can now click "Identify all" to identify your songs. This needs to be done, so that we can find the customsforge id for your songs.
5. Next click "Check all" to check these songs for updates
6. After this is done, you can click "Download all" to open all download links in your browser. CAREFUL: This could open a lot of tabs.
7. After you have replaced the songs on your disk, click "Update selected version numbers". This will set every selected song's current version to the new version.

## Known problems
- The first time you run this program, it will not be able to find the current version of songs. This is because the .psarc files don't contain information that is displayed on the customsforge website. This is out of my reach sadly.
- You have to login into your customsforge account. The website is used to find information about your songs. Sadly there is no other way as customsforge does not have an API or anything similar.
- The update progress can not actually update your files (meaning, replace them with the new file). Users on customsforge upload their files to different file sharing websites, so this is also out of my reach.
