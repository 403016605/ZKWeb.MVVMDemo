﻿var webpack = require('webpack');
var path = require('path');
var webpackMerge = require('webpack-merge');
var HtmlWebpackPlugin = require('html-webpack-plugin');
var CompressionPlugin = require("compression-webpack-plugin");
var ngtools = require('@ngtools/webpack');
var CopyWebpackPlugin = require("copy-webpack-plugin");

var webpackConfig = {
	entry: {
		polyfills: './src/modules/entry_point/polyfills.ts',
		vendor: './src/modules/entry_point/vendor.ts',
		app: './src/modules/entry_point/main.ts'
	},
	output: {
		publicPath: 'dist/',
		path: path.resolve(__dirname, './dist')
	},
	plugins: [
		new ngtools.AotPlugin({
			tsConfigPath: path.resolve(__dirname, './tsconfig.json'),
			entryModule: path.resolve(__dirname, './src/modules/app_module/app.module#AppModule')
		}),
		new webpack.optimize.CommonsChunkPlugin({
			name: ['app', 'vendor', 'polyfills']
		}),
		new CompressionPlugin({
			asset: "[path].gz[query]",
			algorithm: "gzip",
			test: /\.js$|\.html$/,
			threshold: 10240,
			minRatio: 0.3
		}),
		new webpack.optimize.UglifyJsPlugin({ minimize: false }),
		new CopyWebpackPlugin([
			{ from: path.resolve(__dirname, "./src/modules/vendor_module/images/favicon.ico"), to: "favicon.ico" },
			{ from: path.resolve(__dirname, "./src/modules/vendor_module/styles/preloader/preloader.css"), to: "preloader.css" },
		]),
	],
	module: {
		rules: [
			{
				test: /\.ts$/,
				loaders: [ '@ngtools/webpack' ]
			},
			{
				test: /\.css$/,
				loaders: ['to-string-loader', 'css-loader']
			},
			{
				test: /\.scss$/,
				loaders: ['raw-loader', 'sass-loader']
			},
			{
				test: /\.html$/,
				loader: 'raw-loader'
			},
			{
				test: /\.woff(\?v=\d+\.\d+\.\d+)?$/,
				loader: 'url-loader?limit=10000&mimetype=application/font-woff'
			},
			{
				test: /\.woff2(\?v=\d+\.\d+\.\d+)?$/,
				loader: 'url-loader?limit=10000&mimetype=application/font-woff'
			},
			{
				test: /\.ttf(\?v=\d+\.\d+\.\d+)?$/,
				loader: 'url-loader?limit=10000&mimetype=application/octet-stream'
			},
			{
				test: /\.eot(\?v=\d+\.\d+\.\d+)?$/,
				loader: 'file-loader'
			},
			{
				test: /\.svg(\?v=\d+\.\d+\.\d+)?$/,
				loader: 'url-loader?limit=10000&mimetype=image/svg+xml'
			},
		]
	}
};

var defaultConfig = {
	devtool: 'inline-source-map',
	output: {
		filename: '[name].bundle.js',
		chunkFilename: '[id].chunk.js'
	},
	resolve: {
		extensions: ['.ts', '.js'],
		modules: [path.resolve(__dirname, 'node_modules')]
	},
	devServer: {
		contentBase: './',
		port: 3000,
		inline: true,
		stats: 'errors-only',
		historyApiFallback: true,
		watchOptions: { aggregateTimeout: 100, poll: 500 }
	},
	node: {
		global: true,
		crypto: 'empty',
		__dirname: true,
		__filename: true,
		Buffer: false,
		clearImmediate: false,
		setImmediate: false
	}
};

module.exports = webpackMerge(defaultConfig, webpackConfig);
