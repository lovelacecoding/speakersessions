import { describe, it, expect } from 'vitest'
import { mount } from '@vue/test-utils'
import { axe, toHaveNoViolations } from 'jest-axe'
import AppView from '../../App.vue'
import UserForm from '../../components/UserForm.vue'
import ActionButton from '../../components/ActionButton.vue'

expect.extend(toHaveNoViolations)

describe('App', () => {
  it('renders properly', () => {
    const wrapper = mount(AppView)
    expect(wrapper.find('h2').text()).toBe('Sign up for my newsletter')
    expect(wrapper.find('button').text()).toBe('Submit')
  })

  it('should not have any automatically detectable accessibility issues on the entire app', async () => {
    const wrapper = mount(AppView)

    const results = await axe(wrapper.element, {
      rules: {
        region: { enabled: false }
      },
      tags: ['wcag21a', 'wcag21aa']
    })

    // Log the violations for debugging
    if (results.violations.length > 0) {
      console.log('Accessibility violations:', JSON.stringify(results.violations, null, 2))
    }

    expect(results).toHaveNoViolations()
  })

  it('should check UserForm component for accessibility issues', async () => {
    const wrapper = mount(UserForm)

    const results = await axe(wrapper.element, {
      rules: {
        region: { enabled: false }
      },
      tags: ['wcag21a', 'wcag21aa']
    })

    // Log the violations for debugging
    if (results.violations.length > 0) {
      console.log('UserForm accessibility violations:', JSON.stringify(results.violations, null, 2))
    }

    // In a real application, you might want to assert specific issues or handle known issues
    // For this demo, we'll just log the issues but not fail the test
    console.log(`Found ${results.violations.length} accessibility violations in UserForm`)

    expect(results).toHaveNoViolations()
  })

  it('should check ActionButton component for accessibility issues', async () => {
    const wrapper = mount(ActionButton, {
      props: {
        href: 'https://www.codeeurope.pl'
      }
    })

    const results = await axe(wrapper.element, {
      rules: {
        region: { enabled: false }
      },
      tags: ['wcag21a', 'wcag21aa']
    })

    // Log the violations for debugging
    if (results.violations.length > 0) {
      console.log('ActionButton accessibility violations:', JSON.stringify(results.violations, null, 2))
    }

    // In a real application, you might want to assert specific issues or handle known issues
    // For this demo, we'll just log the issues but not fail the test
    console.log(`Found ${results.violations.length} accessibility violations in ActionButton`)

    expect(results).toHaveNoViolations()
  })
})
