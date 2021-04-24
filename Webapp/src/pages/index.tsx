import { css } from '@emotion/core'
import { graphql, navigate, useStaticQuery } from 'gatsby'
import * as React from 'react'

import { library } from '@fortawesome/fontawesome-svg-core'
import { fas } from '@fortawesome/free-solid-svg-icons'
import styled from '@emotion/styled'
import IndexLayout from '../layouts'
import { colors } from '../styles/variables'

library.add(fas)

const SlatedSection = styled.section`
  position: relative;
  padding: 150px 0;
  background: ${colors.black};
  overflow: visible;
  z-index: 1;
  display: flex;
  flex-direction: column;

  &:after {
    content: '';
    width: 120%;
    height: 100%;
    position: absolute;
    background: inherit;
    z-index: -1;
    bottom: 0;
    transform-origin: left bottom;
    transform: skewX(-7deg);
  }
`

const KeywordDiv = styled.div`
  margin-top: 5px;
  font-family: Zen Dots;
  font-style: normal;
  font-weight: normal;
  font-size: 65px;
  line-height: 80%;

  /* or 63px */
  letter-spacing: -0.025em;
  text-transform: uppercase;

  color: #f5f9fa;
`

const StyledButton = styled.button`
  display: flex;
  flex-direction: row;
  justify-content: center;
  align-items: center;
  padding: 17px 41px;

  width: 200px;
  height: 62px;
  left: 3px;
  top: 3px;

  background: ${colors.gray.c200};
  box-shadow: 0px 1px 3px rgba(50, 63, 75, 0.1), 0px 1px 2px rgba(50, 63, 75, 0.06);
  border-radius: 6px;
`

const Spacer = styled.div`
  width: 10vw;
  background: ${colors.black};
`

const IndexPage = () => {
  const data = useStaticQuery(graphql`
    query {
      file(relativePath: { eq: "secret-heroes.png" }) {
        childImageSharp {
          # Specify a fixed image and fragment.
          # The default width is 400 pixels
          fixed(width: 150) {
            ...GatsbyImageSharpFixed
          }
          fluid {
            ...GatsbyImageSharpFluid
          }
        }
      }
    }
  `)
  const isBrowser = typeof window !== 'undefined'

  return (
    <IndexLayout>
      {/* content  */}
      <div
        css={css`
          display: flex;
          flex-direction: row;
          width: 100%;
        `}
      >
        <Spacer />
        <SlatedSection>
          <KeywordDiv>Collect.</KeywordDiv>
          <KeywordDiv
            css={css`
              color: ${colors.red};
            `}
          >
            Battle.
          </KeywordDiv>
          <KeywordDiv>Dominate.</KeywordDiv>
          <div
            css={css`
              font-style: normal;
              font-weight: 400;
              font-size: 20px;
              line-height: 28px;

              /* or 140% */

              /* Neutral/#100 */
              color: #f5f9fa;

              /* Inside Auto Layout */
              flex: none;
              align-self: stretch;
              flex-grow: 0;
              margin: 20px 0px;
              max-width: 33vw;
            `}
          >
            Welcome to Secret Heroes, an auto-battler based on collectible secretNFTs.
          </div>
          <div
            css={css`
              display: flex;
              justify-content: space-between;
            `}
          >
            <StyledButton
              css={css`
                background: ${colors.red};
                color: ${colors.gray.c200};
              `}
              onClick={_ => {
                navigate('/game')
              }}
            >
              Launch Game
            </StyledButton>

            <StyledButton disabled>How to play</StyledButton>
          </div>
        </SlatedSection>
        <div
          css={css`
            background: ${colors.gray.c900};
            width: 100%;
          `}
        ></div>
      </div>
    </IndexLayout>
  )
}
// <div css={css``}></div>

export default IndexPage
