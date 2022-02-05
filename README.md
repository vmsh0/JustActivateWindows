# Just Activate Windows!
Hi! Welcome to JAW.

JAW stands for "Just Activate Windows", and it is a **no-nonsense**, **barebone**, **GUI activator** for recent 64-bit Microsoft Windows operating systems.

JAW should work just fine on any Windows 10 edition, and probably even on Windows 7 (not reccommended!).

JAW also works for Windows 11 Pro. Support for other editions of Windows 11 has not been added yet. If you need it, please open an issue.

It has been **successfully tested** on:
- Windows 10 Pro
- Windows 10 Home
- Windows 10 Enterprise LTSC (2019)
- Windows 11 Pro

You can let me know that it works (or that it doesn't! - please attach the log) on other editions as well by opening an Issue.

### Download
Before downloading JAW, I ask to you to **consider reading** the "Why JAW?" section of this Readme. You can download the latest ready-to-use JAW release from the "releases" page of this GitHub repository.

If you **don't trust me** (which you totally shouldn't, by the way) you can also clone the repository into Visual Studio, get the Tap driver directly from OpenVPN and substitute it to the copy inside the project, compile vlmcsd as a Windows service and substitute that as well, and then compile and run the resulting executable.

### Activation instructions
The plan is to eventually make this a one-click process, but for now **this is what you have to do**:
- Click on "Backup current key" (you can skip this on a fresh Windows install)
- Click on "Install VL key"
- Click on "Install Tap device"
- Click on "Register service, add firewall rule and Activate"

Each **Step** on the GUI **will only activate** if it is necessary and if the previous Step has been completed. In particular, the Product key step may not be necessary if your Windows edition is already configured for Volume activation, so you may need to start from Step 2.

Each Step has a **"?" button** which explains the Step in detail. When you start a Step, a message will be shown informing you of what is going to happen.

Everything JAW does is **fully reversible**, except (for now) for the firewall rule, which however is completely harmless and won't expose anything on your computer to any external network.

There are also some **"Uninstall/repair" buttons**. These are pretty self-explainatory. You shouldn't use the "Advanced" buttons unless you understand what they do; in any case, even these are not going to do any irreversible damage to your system.

### Do I need to keep JAW on my PC after the process?
No. JAW installs and configure the necessary Tap driver and KMS emulator service, which then work autonomously.

### JAW doesn't work
Sorry to hear that! Please, **open an Issue** on this repository as follows:
- **Explain** what you did, what you expected and what happened instead
- **Attach the *jaw.log* file**, which you can find in the same directory as the JAW executable (note: the file gets overwritten every time you restart JAW, so, if something goes wrong, it may be a good idea to make a copy of the file before restarting JAW)
- If you got a **runtime error or exception**, a dialog should have appeared on your screen, containing a long piece of text full of technical stuff; if that's the case, please **make a screenshot** of the dialog, **copy all the text** into a text file, and **attach** both to the Issue

## Some cheap ethics
Why JAW? Because **the alternatives suck**:

- **Buying Windows at full price...** if you are here, you've already decided against that, and I surely can't fix that.
- **Buying "cheap keys" online...** very convenient, but those keys are either stolen or legally void (i.e. *technically* they may activate Windows, but they are at best just as illegal as an activator).
- **Manually running a KMS emulator...** complicated and annoying, especially if you like to clean-install often.
- **Using a different GUI activator...** most are not Open Source, only available behind forum registrations/ad-walls and complicated.
- **Using an hwid generator...** *technically* the same as using an activator, but way more controversial both legally and ethically: by using an hwid generator you are submitting false data to Microsoft to obtain a permanent license you have not right to have.

### Does any of this justify using an activator?
If you don't own a license to use Microsoft Windows on the computer you're installing it on (no, cheap keys purchased online don't count), then **none of what I stated justifies using an activator**. But since you, like many other people, have still decided to do that, I want you to be able to use an Open Source, easy-to-use and readily available one, the author of which cares enough to explain what it actually does to your system.

I believe this piece of software (and this way of thinking) **benefits** both **the end users** and **Microsoft**. Two very practical benefits it has are that **it minimizes the chance that something will go wrong** (malware, data loss, general frustration because you just want to get on with your life) and **de-incentivizes the commerce of "cheap keys"** (because now the alternative is just as practical).

Of course, if you own a valid Microsoft Windows license for your computer, then none of this really applies. You have a right to use the software you've bought!

### What if I don't want to buy Microsoft Windows, but I also don't want to use it illegally?
If you can, **switch** to using a **GNU/Linux** distribution. I suggest Debian and Arch Linux.

I regularly use GNU/Linux, but as of today it cannot /fully/ satisfy my computing needs; thus, I compromise and also use Microsoft Windows. Although I own a Windows license, I still use JAW to activate it on my PC, because [DRM is evil](https://www.eff.org/issues/drm) and I don't bother with it.

## What kind of activation does JAW perform?
JAW performs **KMS activation**, using a dummy KMS server (from the vlmcsd project).

### How does it work?
This is very approximate. Please **read the source code** to find out more!

- **Key installation.** The system is checked for existing keys. If the main key is the correct VL key, JAW proceeds to the next step; otherwise, it clears all keys and installs the correct one.
- **Tap driver installation.** JAW installs a Tap driver (currently, the tap0901 driver from the OpenVPN project) and configures it for the dummy KMS server.
- **Service installation and activation.** JAW installs the dummy KMS server as a services, which will listen on the Tap driver interface, and configures the Windows firewall accordingly. The Software Licensing Service is then configured to use the dummy KMS server for activation, and the activation is triggered.

**Further documentation** can also be obtained by running JAW and clicking on the *?* button for each step.

## How can I contribute?
This is the current **to-do list** (some of these items are further detailed in the issue tracker):

#### Code-related
- Generally improve the code, which as of now is pretty rudimentary
- Revamp the GUI
- Put more sanity checks throughout the WMI operations
- Make the firewall step reversible
- Localization support

#### Project-related
- Localization (depends upon Localization support)
- Better release process (incl. compiling vlmcsd as part of the build process and automatic versioning based off git commit id and tag - I have no idea how to do that with MSBuild and I don't care to learn, so please help!)

Some of these items have a **corresponding Issue** in the tracker with more details.

**Everyone is welcome** to work on these items. The correct way to do that is to **fork** the repository, **do** the work and submit a **Pull request**. If you are unsure about something, open an Issue.

Please follow the **existing coding style**. I will not accept PRs contaning badly-formatted code, mixed tab and spaces (and in general different indentation style), with identifiers written in a language different than English and any other form of bad code.

I will only accept **GPLv3-licensed contributions**. If you add source code files, make sure to insert the license notice at the top, and, if you wish, also add a copyright notice with your name (copy both from an existing source code file, and either update or delete the copyright notice).

If you think I should add something else to the list, please open an Issue.

## Licenses
JAW is released under the GPLv3 license. You can find a copy in the "COPYING" file.

The OpenVPN Tap-windows driver is released under the GPLv2 license with a special exception for linkage against the WDK. You can find the source code and the full license [here](https://github.com/OpenVPN/tap-windows).

I don't known what license vlmcsd is released under. I can't find any related information in the repository. If you have this information, please open an Issue.
