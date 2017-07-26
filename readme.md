# TagHelper for responsive image

> TagHelper &lt;responsive-image&gt; for asp.net

This is a simple tag helper which adds responsive image feature to the default image tag.

To be used like this:

```html
<responsive-image 
    base-image-url="http://via.placeholder.com" 
    fallback-size="130" 
    sizes="(min-width: 1000px) 50vw, 100vw"
    srcset="160,250,320,400,500,640,700,800,950,1100,1190,1280,1400,1600,1800,2000" 
    lazy="false">
</responsive-image>
```

Please update `ResponsiveImageTagHelper.cs` to manage the URL concatenation of your images.