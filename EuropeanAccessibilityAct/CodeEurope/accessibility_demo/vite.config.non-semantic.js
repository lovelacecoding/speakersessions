import { fileURLToPath, URL } from 'node:url'

import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'

// Custom plugin to replace the entry point in index.html
const replaceEntryPlugin = () => {
  return {
    name: 'replace-entry',
    transformIndexHtml(html) {
      return html.replace(
        '<script type="module" src="/src/main.js"></script>',
        '<script type="module" src="/src/main-non-semantic.js"></script>'
      )
    }
  }
}

// https://vite.dev/config/
export default defineConfig({
  plugins: [
    vue(),
    replaceEntryPlugin(),
  ],
  resolve: {
    alias: {
      '@': fileURLToPath(new URL('./src', import.meta.url))
    },
  },
  // Custom entry point for both development and build
  build: {
    rollupOptions: {
      input: {
        main: fileURLToPath(new URL('./index.html', import.meta.url)),
      },
    },
  },
  // Override the entry point for the development server
  server: {
    fs: {
      // Allow serving files from one level up to the project root
      allow: ['..']
    }
  },
  // Specify the entry point for the application
  optimizeDeps: {
    entries: [
      './src/main-non-semantic.js'
    ]
  }
})
