# ArcTouch Xamarin Code Challenge

This project consists on the improvement of an already existing version of an app for movie hobbysts and cinephiles. The initial version of the app was barebones, and I was assigned to fix some of it's shortcomings and improve the app usability in general. 
The app consumes content from [The Movie Database](https://www.themoviedb.org).

## Screenshots

### Android
<p float="left">
  <img src="/Screenshots/Screenshot-Android-01.png" alt="Splashscreen"/>
  <img src="/Screenshots/Screenshot-Android-02.png" alt="Home Screen" />
  <img src="/Screenshots/Screenshot-Android-03.png" alt="Details Screen"/>
</p>

### iOS
<p float="left">
  <img src="/Screenshots/Screenshot-iOS-01.png" alt="Splashscreen"/>
  <img src="/Screenshots/Screenshot-iOS-02.png" alt="Home Screen" />
  <img src="/Screenshots/Screenshot-iOS-03.png" alt="Details Screen"/>
</p>

## More Information
[Project Tasks](https://github.com/DioMuller/code-challenge-xamarin/issues)

## Environment

### Development
* Windows 10 with Visual Studio Community 2019 Version 16.4.5.
* Mac running macOS Mojave 10.14.6, with Visual Studio for Mac version 8.3.4.

### Tests
* Google's Android emulator .
* Apple's iOS emulator.
* Motorola Play X running Android 7.1.1.
* iPhone 6S running iOS 13.3.1.

## Libraries
The project is configured to download it's dependencies automatically via Nuget.
It uses Xamarin.Forms and it's dependencies to create a multi-platform app.
Other than that, some libraries were used to facilitate the completion of the given tasks.

#### Autofac (5.1.2)
Used to create an Inversion of Control (IoC) Container, to isolate the Views from the ViewModels and facilitate dependency injection on the app.

#### Refit (5.0.23)
Used to make REST calls to The Movie Database's server.

#### Xamarin.FFImageLoading and Xamarin.FFImageLoading.Forms (2.4.11.982)
Used to cache images, improving loading times for previously downloaded images and facilitating their rendering.

#### Xamarin.Forms.Visual.Material (4.4.0.991640)
Used to create a more consistent experience, with similar components and styles on both platforms.

## Contributing
This project is a Code Challenge, and for that reason, no external contributions will be accepted.

## License
All the code in this repository is owned by ArcTouch, and should not be used without their permission.
