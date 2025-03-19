import { describe, it, expect } from 'vitest'
import { mount } from '@vue/test-utils'
import { axe, toHaveNoViolations } from 'jest-axe'
import AppView from '../../App.vue'

expect.extend(toHaveNoViolations)

describe('App', () => {
  it('renders properly', () => {
    const wrapper = mount(AppView)
    expect(wrapper.find('h2').text()).toBe('Sign up for my newsletter')
    expect(wrapper.find('button').text()).toBe('Submit')
  })

  it('has no accessibility violations', async () => {
    const wrapper = mount(AppView)

    const results = await axe(wrapper.element, {
      rules: {
        region: { enabled: false }
      }
    })
    expect(results).toHaveNoViolations()
  })
})
