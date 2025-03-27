/// <binding AfterBuild='compile-scripts' />
//const gulp = require('gulp');
//const webpackStream = require('webpack-stream');
import gulp from 'gulp'
import rename from 'gulp-rename';
import { VueLoaderPlugin } from 'vue-loader';
import webpackStream from 'webpack-stream';
import webpack  from 'webpack';

const dest = '../UmbracoProject';

gulp.task('compile-scripts',
  async function () {
    return await gulp.src(['./src/main.js'])
      .pipe(webpackStream({
        mode: 'development',
        module: {
          rules: [
            {
              test: /\.js$/,
              exclude: /node_modules/,
              loader: "babel-loader"
            },
            {
              test: /\.vue$/,
              loader: 'vue-loader',

            },

            {
              test: /\.css$/,
              use: [
                'vue-style-loader',
                'css-loader'
              ]
            },
          ]
        },
        plugins: [
          new VueLoaderPlugin(),
          
          new webpack.DefinePlugin({
            __VUE_OPTIONS_API__: true,
            __VUE_PROD_DEVTOOLS__: true,
            __VUE_PROD_HYDRATION_MISMATCH_DETAILS__: true, 
          })
        ]
      }))
      .pipe(rename('bundle.min.js'))
      .pipe(gulp.dest(dest + '/wwwroot/assets/js/'));
  });

gulp.task('watch', function () {
  gulp.watch('./src/**/*.vue', gulp.series('build'))
  gulp.watch('./src/**/*.js', gulp.series('build'))
});

gulp.task('watch', function () {
  gulp.watch('./src/**/*.vue', gulp.series(['compile-scripts']))
  gulp.watch('./src/**/*.js', gulp.series(['compile-scripts']))
});
