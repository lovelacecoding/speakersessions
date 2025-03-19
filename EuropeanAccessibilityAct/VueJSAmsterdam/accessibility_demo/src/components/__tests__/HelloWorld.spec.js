import { describe, it, expect } from 'vitest'
import { mount } from '@vue/test-utils'
import { axe, toHaveNoViolations } from 'jest-axe'
import HelloWorld from '../HelloWorld.vue'

expect.extend(toHaveNoViolations)

describe('HelloWorld', () => {
  it('renders properly', () => {
    const wrapper = mount(HelloWorld, { props: { msg: 'Hello Vitest' } })
    expect(wrapper.text()).toContain('Hello Vitest')
  })

  it('has no accessibility violations', async () => {
    const wrapper = mount(HelloWorld, { props: { msg: 'Hello Vitest' } })

    const results = await axe(wrapper.element)

    expect(results).toHaveNoViolations()
  })
})
