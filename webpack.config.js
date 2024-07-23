const path = require('path');
const { VueLoaderPlugin } = require('vue-loader');

module.exports = {
    entry: './wwwroot/scripts/main.js',
    output: {
        filename: 'bundle.js',
        path: path.resolve(__dirname, 'wwwroot/js'),
    },
    module: {
        rules: [
            {
                test: /\.vue$/,
                loader: 'vue-loader',
            },
            {
                test: /\.js$/,
                loader: 'babel-loader',
                exclude: /node_modules/,
            },
            {
                test: /\.css$/,
                use: ['style-loader', 'css-loader'],
            },
        ],
    },
    plugins: [
        new VueLoaderPlugin(),
    ],
    devServer: {
        static: {
            directory: path.join(__dirname, 'wwwroot'),
        },
        compress: true,
        port: 9000,
    },
};
