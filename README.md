# Qobuz Music Downloader

A Windows desktop application for downloading high-quality music from Qobuz through a third-party API service called [QobuzDL](https://qqdl.site/). This application provides a user-friendly interface for searching, browsing, and downloading albums and tracks in various audio quality formats.

## Features

- **Music Search & Discovery**

  - Search for albums, tracks, and artists
  - Browse search results with album artwork and metadata
  - Filter results by type (Albums, Tracks, Artists)
  - Pagination support for large result sets

- **High-Quality Audio Downloads**

  - Support for multiple audio quality formats:
    - Hi-Res (up to 24-bit/192kHz)
    - FLAC Lossless
    - CD Quality (16-bit/44.1kHz)
    - MP3 320kbps
  - Organized folder structure: `Artist/Album/Tracks`
  - Concurrent downloads with configurable thread limits

- **User-Friendly Interface**

  - Windows Forms GUI with modern design
  - Real-time download progress tracking
  - Album cover display and caching
  - Configurable settings panel

- **Customizable Settings**
  - Custom download location
  - Adjustable concurrent download limits
  - Search result limits
  - API endpoint configuration
  - Audio quality preferences

## Technical Details

- **Framework**: .NET 8.0 Windows Forms Application
- **Language**: C#
- **Dependencies**: RestSharp for HTTP API communication
- **Architecture**: Modular design with separate API client, data models, and UI components

## Requirements

- Windows operating system
- .NET 8.0 Runtime
- Active internet connection
- Access to compatible Qobuz API service

## Usage

1. Configure API endpoint and download preferences in Settings
2. Search for music using the search bar
3. Browse results and select albums or tracks to download
4. Click "Download Selected" to begin downloading in your chosen quality

## Project Structure

- **QobuzDL/**: Core API client and data models for Qobuz integration
- **Forms/**: Windows Forms UI components (Main interface and Settings)
- **Properties/**: Application settings and resources
- **Resources/**: Application icons and assets

## Disclaimer

This application is for educational purposes. Users are responsible for ensuring they have proper rights and permissions for any content they download. Respect copyright laws and the terms of service of music platforms.
