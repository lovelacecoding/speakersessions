import { test, expect } from '@playwright/test';
import AxeBuilder from '@axe-core/playwright';

test.describe('Accessibility tests', () => {
  test('should not have any automatically detectable accessibility issues on the home page', async ({ page }) => {
    await page.goto('/');

    const accessibilityScanResults = await new AxeBuilder({ page })
      .withTags(['wcag2a', 'wcag2aa', 'wcag21a', 'wcag21aa'])
      .analyze();

    // Log the violations for debugging
    if (accessibilityScanResults.violations.length > 0) {
      console.log('Accessibility violations:', JSON.stringify(accessibilityScanResults.violations, null, 2));
    }

    // This test will fail if there are any accessibility violations
    // In a real-world scenario, you might want to handle known issues differently
    expect(accessibilityScanResults.violations).toEqual([]);
  });

  test('should check UserForm component for accessibility issues', async ({ page }) => {
    await page.goto('/');

    // Use a selector
    const sectionSelector = '#newsletter-signup';

    // Always wait until the element is really in the DOM
    await page.locator(sectionSelector).waitFor({ state: 'attached' });


    const accessibilityScanResults = await new AxeBuilder({ page })
      .include(sectionSelector)
      .withTags(['wcag2a', 'wcag2aa', 'wcag21a', 'wcag21aa'])
      .analyze();

    // Log the violations for debugging
    if (accessibilityScanResults.violations.length > 0) {
      console.log('UserForm accessibility violations:', JSON.stringify(accessibilityScanResults.violations, null, 2));
    }

    // In a real application, you might want to assert specific issues or handle known issues
    // For this demo, we'll just log the issues but not fail the test
    console.log(`Found ${accessibilityScanResults.violations.length} accessibility violations in UserForm`);

    expect(accessibilityScanResults.violations).toEqual([]);
  });

  test('should check ActionButton component for accessibility issues', async ({ page }) => {
    await page.goto('/');

    // Use a selector
    const sectionSelector = '#actionbutton';

    // Always wait until the element is really in the DOM
    await page.locator(sectionSelector).waitFor({ state: 'attached' });


    const accessibilityScanResults = await new AxeBuilder({ page })
      .include(sectionSelector)
      .withTags(['wcag2a', 'wcag2aa', 'wcag21a', 'wcag21aa'])
      .analyze();

    // Log the violations for debugging
    if (accessibilityScanResults.violations.length > 0) {
      console.log('UserForm accessibility violations:', JSON.stringify(accessibilityScanResults.violations, null, 2));
    }

    // In a real application, you might want to assert specific issues or handle known issues
    // For this demo, we'll just log the issues but not fail the test
    console.log(`Found ${accessibilityScanResults.violations.length} accessibility violations in ActionButton`);

    expect(accessibilityScanResults.violations).toEqual([]);
  });
});
