# accessibility_demo1

This template should help get you started developing with Vue 3 in Vite.


## Project Setup

```sh
npm install
```

### Run semantic + top 6 errors version
Semantic version with issues like missing alt text, empty links and buttons, and contrast issues
```sh
npm run dev
```

### Run semantic version
```sh
npm run dev:semantic
```

### Run Non-Semantic Version

This version uses only div elements instead of semantic HTML elements.

```sh
npm run dev:non-semantic
```

### Run Unit Tests with [Vitest](https://vitest.dev/)

```sh
npm run test:unit
```

### Run Accessibility Tests with [Playwright](https://playwright.dev/)

```sh
npm run test:e2e
```
